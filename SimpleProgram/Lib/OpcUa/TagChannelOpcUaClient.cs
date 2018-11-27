using System;
using Opc.Ua.Client;
using SimpleProgram.Lib.Tag;

namespace SimpleProgram.Lib.OpcUa
{
    public class TagChannelOpcUaClient
    {
        public TagChannelOpcUaClient(OpcUaClient client, string nodeId, int samplingInterval)
        {
            Client = client;
            NodeId = nodeId;
            SamplingInterval = samplingInterval;

            Client.AddMonitoredItem(this, NodeId, SamplingInterval, OnNewValueFromChannel);
        }

        public OpcUaClient Client { get; }
        public int SamplingInterval { get; }
        public string NodeId { get; }

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
    }
}