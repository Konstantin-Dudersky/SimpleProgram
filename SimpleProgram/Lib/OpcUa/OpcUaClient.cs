using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Opc.Ua;
using Opc.Ua.Client;
using Opc.Ua.Configuration;

namespace SimpleProgram.Lib.OpcUa
{
    public enum ExitCode
    {
        Ok = 0,
        ErrorCreateApplication = 0x11,
        ErrorDiscoverEndpoints = 0x12,
        ErrorCreateSession = 0x13,
        ErrorBrowseNamespace = 0x14,
        ErrorCreateSubscription = 0x15,
        ErrorMonitoredItem = 0x16,
        ErrorAddSubscription = 0x17,
        ErrorRunning = 0x18,
        ErrorNoKeepAlive = 0x30,
        ErrorInvalidCommandLine = 0x100
    }

    public class OpcUaClient : SimpleProgramChannelBase
    {
        private const int ReconnectPeriod = 10;
        public string EndpointUrl { get; }

        private readonly List<MonitoredItem> _monitoredItems = new List<MonitoredItem>();
        private readonly Timer _timer;
        private SessionReconnectHandler _reconnectHandler;
        public Session Session { get; private set; }

        public OpcUaClient(string channelName, string endpointUrl, bool disabled = false) 
            : base(channelName, disabled)
        {
            EndpointUrl = endpointUrl;
            _timer = new Timer(obj => Run(), null, 0, ReconnectPeriod * 1000);
            if (disabled) _timer.Dispose();
        }

        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        private static ExitCode ExitCode { get; set; }

        private void Run()
        {
            try
            {
                Client().Wait();
                
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return;
            }

            ExitCode = ExitCode.Ok;
        }

        private async Task Client()
        {
            Logger.Info("1 - Create an Application Configuration.");
            ExitCode = ExitCode.ErrorCreateApplication;

            var application = new ApplicationInstance
            {
                ApplicationType = ApplicationType.Client,
                ConfigSectionName = nameof(OpcUaClient)
            };

            // load the application configuration.
            var config = await application.LoadApplicationConfiguration("OpcUaClient.Config.xml", false);

            // check the application certificate.
            var haveAppCertificate = await application.CheckApplicationInstanceCertificate(false, 0);
            if (!haveAppCertificate) throw new Exception("Application instance certificate invalid!");

            config.ApplicationUri =
                Utils.GetApplicationUriFromCertificate(config.SecurityConfiguration.ApplicationCertificate
                    .Certificate);
            config.CertificateValidator.CertificateValidation += CertificateValidator_CertificateValidation;

            Logger.Info("2 - Discover endpoints of {0}.", EndpointUrl);
            ExitCode = ExitCode.ErrorDiscoverEndpoints;
            var selectedEndpoint = CoreClientUtils.SelectEndpoint(EndpointUrl, true, 15000);
            Logger.Info("    Selected endpoint uses: {0}",
                selectedEndpoint.SecurityPolicyUri.Substring(selectedEndpoint.SecurityPolicyUri.LastIndexOf('#') + 1));

            Logger.Info("3 - Create a session with OPC UA server.");
            ExitCode = ExitCode.ErrorCreateSession;
            var endpointConfiguration = EndpointConfiguration.Create(config);
            var endpoint = new ConfiguredEndpoint(null, selectedEndpoint, endpointConfiguration);
            Session = await Session.Create(config, endpoint, false, "OPC UA Console Client", 60000,
                new UserIdentity(new AnonymousIdentityToken()), null);
            
            // register keep alive handler
            Session.KeepAlive += Client_KeepAlive;

            Logger.Info("4 - Browse the OPC UA server namespace.");
            ExitCode = ExitCode.ErrorBrowseNamespace;
            /*byte[] continuationPoint;

            var references = _session.FetchReferences(ObjectIds.ObjectsFolder);

            _session.Browse(
                null,
                null,
                ObjectIds.ObjectsFolder,
                0u,
                BrowseDirection.Forward,
                ReferenceTypeIds.HierarchicalReferences,
                true,
                (uint) NodeClass.Variable | (uint) NodeClass.Object | (uint) NodeClass.Method,
                out continuationPoint,
                out references);

            Console.WriteLine(" DisplayName, BrowseName, NodeClass");
            foreach (var rd in references)
            {
                Console.WriteLine(" {0}, {1}, {2}", rd.DisplayName, rd.BrowseName, rd.NodeClass);
                ReferenceDescriptionCollection nextRefs;
                byte[] nextCp;
                _session.Browse(
                    null,
                    null,
                    ExpandedNodeId.ToNodeId(rd.NodeId, _session.NamespaceUris),
                    0u,
                    BrowseDirection.Forward,
                    ReferenceTypeIds.HierarchicalReferences,
                    true,
                    (uint) NodeClass.Variable | (uint) NodeClass.Object | (uint) NodeClass.Method,
                    out nextCp,
                    out nextRefs);

                foreach (var nextRd in nextRefs)
                    Console.WriteLine("   + {0}, {1}, {2}", nextRd.DisplayName, nextRd.BrowseName,
                        nextRd.NodeId);
            }*/

            Logger.Info("5 - Create a subscription with publishing interval of 1 second.");
            ExitCode = ExitCode.ErrorCreateSubscription;
            var subscription = new Subscription(Session.DefaultSubscription)
            {
                PublishingInterval = 1000
            };

            Logger.Info("6 - Add a list of items (server current time and status) to the subscription.");
            ExitCode = ExitCode.ErrorMonitoredItem;
            var list = new List<MonitoredItem>
            {
                new MonitoredItem(subscription.DefaultItem)
                {
                    DisplayName = "ServerStatusCurrentTime",
                    StartNodeId = "i=" + Variables.Server_ServerStatus_CurrentTime
                }
            };
            list.AddRange(_monitoredItems);
            subscription.AddItems(list);

            Logger.Info("7 - Add the subscription to the session.");
            ExitCode = ExitCode.ErrorAddSubscription;
            Session.AddSubscription(subscription);
            subscription.Create();

            ExitCode = ExitCode.ErrorRunning;

            IsConnected = true;
            
            _timer.Dispose();
        }

        private void Client_KeepAlive(Session sender, KeepAliveEventArgs e)
        {
            if (e.Status == null || !ServiceResult.IsNotGood(e.Status)) return;
            Logger.Info("{0} {1}/{2}", e.Status, sender.OutstandingRequestCount, sender.DefunctRequestCount);
            
            IsConnected = false;

            if (_reconnectHandler != null) return;
            Logger.Info("--- RECONNECTING ---");
            _reconnectHandler = new SessionReconnectHandler();
            _reconnectHandler.BeginReconnect(sender, ReconnectPeriod * 1000, Client_ReconnectComplete);
        }

        private void Client_ReconnectComplete(object sender, EventArgs e)
        {
            // ignore callbacks from discarded objects.
            if (!ReferenceEquals(sender, _reconnectHandler)) return;

            Session = _reconnectHandler.Session;
            _reconnectHandler.Dispose();
            _reconnectHandler = null;

            Logger.Info("--- RECONNECTED ---");
        }

        private static void CertificateValidator_CertificateValidation(CertificateValidator validator,
            CertificateValidationEventArgs e)
        {
            if (e.Error.StatusCode != StatusCodes.BadCertificateUntrusted) return;
            e.Accept = true;
            Console.WriteLine("Accepted Certificate: {0}", e.Certificate.Subject);
        }

        public void AddMonitoredItem(TagChannelOpcUaClient client, string nodeId, int samplingInterval,
            MonitoredItemNotificationEventHandler eventHandler)
        {
            var monitoredItem = new MonitoredItem
            {
                StartNodeId = nodeId,
                SamplingInterval = samplingInterval
            };
            _monitoredItems.Add(monitoredItem);
            monitoredItem.Notification += eventHandler;
            client.NewValueToChannel += OnNewValueToChannel;
        }

        private void OnNewValueToChannel(object sender, ValueToChannelArgs eventArgs)
        {
            var dataValue = Session.ReadValue(eventArgs.NodeId);
            
            dataValue.Value = eventArgs.Value;
            var writeValueCollection = new WriteValueCollection
            {
                new WriteValue
                {
                    Value = new DataValue(
                        new Variant(Convert.ChangeType(dataValue.Value, dataValue.Value.GetType()))),
                    NodeId = eventArgs.NodeId,
                    AttributeId = Attributes.Value
                }
            };

            Session.Write(null, writeValueCollection, out var status, out _);

            foreach (var s in status)
            {
                if (s != StatusCodes.Good)
                    Logger.Info($"{eventArgs.NodeId}\t{s}");
            }
        }
    }

    public class ValueToChannelArgs : EventArgs
    {
        public ValueToChannelArgs(string nodeId, object value)
        {
            NodeId = nodeId;
            Value = value;
        }

        public string NodeId { get; }
        public object Value { get; }
    }
}