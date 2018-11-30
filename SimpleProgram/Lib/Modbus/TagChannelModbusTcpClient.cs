using System;
using SimpleProgram.Lib.Tag;

namespace SimpleProgram.Lib.Modbus
{
    public class TagChannelModbusTcpClient
    {
        private readonly ModbusTcpClient _client;
        private readonly ushort _startAddress;
        private readonly int _samplingInterval;

        public TagChannelModbusTcpClient(ModbusTcpClient client, ushort startAddress, int samplingInterval)
        {
            _client = client;
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