using System;
using SimpleProgram.Lib.Tag;

namespace SimpleProgram.Channels.ModbusTcpClient
{
    public class TagChannelModbusTcpClient
    {
        public ModbusTcpClient Client { get; }
        private readonly ushort _startAddress;
        private readonly int _samplingInterval;

        public TagChannelModbusTcpClient(ModbusTcpClient client, ushort startAddress, int samplingInterval)
        {
            Client = client;
            _startAddress = startAddress;
            _samplingInterval = samplingInterval;
            
            client.AddMonitoredItem(this, _startAddress, _samplingInterval, OnNewValueFromChannel);
        }

        private void OnNewValueFromChannel(object sender, ValueFromChannelArgs e)
        {
            NewValueFromChannel?.Invoke(this, new TagExchangeWithChannelArgs(e.Value, DateTime.Now));
        }
        
        public void OnNewValueToChannel(object sender, TagExchangeWithChannelArgs eventArgs)
        {
            NewValueToChannel?.Invoke(this, new ValueToChannelArgs(_startAddress, eventArgs.Value));
        }
        
        public event EventHandler<TagExchangeWithChannelArgs> NewValueFromChannel;
        internal event EventHandler<ValueToChannelArgs> NewValueToChannel;
    }
}