using System;
using System.Threading.Tasks;
using Opc.Ua;
using Opc.Ua.Client;
using SimpleProgram.Lib.Archives;
using SimpleProgram.Lib.Tag;

namespace SimpleProgram.Channels.OpcUaClient
{
    public class TagChannelOpcUaClient : ITagChannelHistory
    {
        public TagChannelOpcUaClient(OpcUaClient client, string nodeId, int samplingInterval, bool historizing)
        {
            Client = client;
            NodeId = nodeId;
            SamplingInterval = samplingInterval;
            Historizing = historizing;

            Client.AddMonitoredItem(this, NodeId, SamplingInterval, OnNewValueFromChannel);
        }

        public OpcUaClient Client { get; }
        public int SamplingInterval { get; }
        public string NodeId { get; }
        public bool Historizing { get; }

        private void OnNewValueFromChannel(MonitoredItem item, MonitoredItemNotificationEventArgs e)
        {
            foreach (var value in item.DequeueValues())
                NewValueFromChannel?.Invoke(this, new TagExchangeWithChannelArgs(value.Value, value.SourceTimestamp));
        }

        public void OnNewValueToChannel(object sender, TagExchangeWithChannelArgs eventArgs)
        {
            NewValueToChannel?.Invoke(this, new ValueToChannelArgs(NodeId, eventArgs.Value));
        }

        public event EventHandler<TagExchangeWithChannelArgs> NewValueFromChannel;
        public event EventHandler<ValueToChannelArgs> NewValueToChannel;


        #region ITagChannelHistory

        public void DeleteArchiveData(DateTime begin, DateTime end, double lessThen, double moreThen)
        {
            throw new NotImplementedException();
        }

        public async Task<TimeSeries> GetTimeSeriesAsync(DateTime dateTimeFrom, DateTime dateTimeTo,
            double lessThen, double moreThen)
        {
            return await Task.Run(() =>
            {
                var details = new ReadRawModifiedDetails
                {
                    StartTime = dateTimeFrom,
                    EndTime = dateTimeTo,
                    ReturnBounds = false
                };

                var nodesToRead = new HistoryReadValueIdCollection
                {
                    new HistoryReadValueId {NodeId = NodeId}
                };

                Client.Session.HistoryRead(
                    null,
                    new ExtensionObject(details),
                    TimestampsToReturn.Source,
                    false,
                    nodesToRead,
                    out var results,
                    out var diagnosticInfos);

                ClientBase.ValidateResponse(results, nodesToRead);
                ClientBase.ValidateDiagnosticInfos(diagnosticInfos, nodesToRead);

                if (StatusCode.IsBad(results[0].StatusCode))
                    throw new ServiceResultException(results[0].StatusCode);

                var data = ExtensionObject.ToEncodeable(results[0].HistoryData) as HistoryData;

                var ts = new TimeSeries();

                if (data == null) return ts;

                foreach (var result in data.DataValues)
                    ts.Add(result.SourceTimestamp.ToLocalTime(), (double) result.Value);

                return ts;
            });
        }

        public Task<double> GetArchiveValueAsync(DateTime begin, DateTime end,
            SimplifyType simplifyType = SimplifyType.None)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}