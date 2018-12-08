using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using NLog.Config;
using NModbus;
using SimpleProgram.Lib.OpcUa;

namespace SimpleProgram.Lib.Modbus
{
    public class ModbusTcpClient : SimpleProgramChannelBase
    {
        private const int ReconnectPeriod = 5000;
        private const int MinSamplingInterval = 1000;
        
        private readonly List<MonitoredItem> _items = new List<MonitoredItem>();

        private int _currRelSamplingInterval = 1;
        private int _maxRelSamplingInterval;

        private readonly string _ip;
        private readonly int _port;
        private readonly byte _slaveAddress;
        private readonly bool _disabled;
        private IModbusMaster _master;

        // ReSharper disable once NotAccessedField.Local
        private readonly Timer _timerCyclicRead;
        private readonly Timer _timerReconnect;

        private bool _connected;

        public ModbusTcpClient(string channelName, string ip, int port, byte slaveAddress, bool disabled = false) 
            : base(channelName, disabled)
        {
            _ip = ip;
            _port = port;
            _slaveAddress = slaveAddress;
            _disabled = disabled;

            if (_disabled) return;
                
            _timerReconnect = new Timer(Reconnect);
            SetConnected(false);
            _timerCyclicRead = new Timer(TimerCyclicRead, null, 0, MinSamplingInterval);
        }

        private void Reconnect(object obj)
        {
            if (_disabled) return;
            
            try
            {
                var client = new TcpClient(_ip, _port);
                var factory = new ModbusFactory();
                _master = factory.CreateMaster(client);

                SetConnected(true);
            }
            catch (Exception e)
            {
                Logger.Error(e, "Не удалось подключиться к Modbus TCP серверу");
                
                if (_connected) SetConnected(false);
            }
        }

        private void SetConnected(bool connected)
        {
            if (connected)
            {
                _connected = true;
                _timerReconnect.Change(Timeout.Infinite, Timeout.Infinite);
                Logger.Info("Подключение к Modbus TCP серверу создано");
            }
            else
            {
                _connected = false;
                _timerReconnect.Change(0, ReconnectPeriod);
            }
        }

        private void TimerCyclicRead(object obj)
        {
            if (!_connected || _disabled) return;

            foreach (var item in _items)
            {
                if (item.RelSamplingInterval > _currRelSamplingInterval) continue;
                
                try
                {
                    var value = _master.ReadHoldingRegisters(_slaveAddress, item.StartAddress, 1);
                    item.NewValueFromChannel(value[0]);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    SetConnected(false);
                    return;
                }
            }

            _currRelSamplingInterval++;
            if (_currRelSamplingInterval > _maxRelSamplingInterval)
                _currRelSamplingInterval = 1;
        }

        internal void AddMonitoredItem(TagChannelModbusTcpClient client, ushort startAddress, int samplingInterval, 
            EventHandler<ValueFromChannelArgs> eventHandler)
        {
            var relSamplingInterval = (int) Math.Ceiling((double) samplingInterval / MinSamplingInterval);

            _maxRelSamplingInterval = Math.Max(_maxRelSamplingInterval, relSamplingInterval);
            
            var item = new MonitoredItem(startAddress, relSamplingInterval);
            item.OnNewValueFromChannel += eventHandler;
            _items.Add(item);
            
            client.NewValueToChannel += OnNewValueToChannel;
        }

        private void OnNewValueToChannel(object sender, ValueToChannelArgs e)
        {
            if (!_connected) return;

            _master.WriteSingleRegister(_slaveAddress, e.StartAddress, Convert.ToUInt16(e.Value));
        }

        private class MonitoredItem
        {
            internal event EventHandler<ValueFromChannelArgs> OnNewValueFromChannel;
            internal ushort StartAddress { get; }
            internal int RelSamplingInterval { get; }
            
            public MonitoredItem(ushort startAddress, int relSamplingInterval)
            {
                StartAddress = startAddress;
                RelSamplingInterval = relSamplingInterval;
            }

            internal void NewValueFromChannel(int value)
            {
                OnNewValueFromChannel?.Invoke(this, new ValueFromChannelArgs(value));
            }
        }
    }
    
    internal class ValueFromChannelArgs
    {
        public ValueFromChannelArgs(int value)
        {
            Value = value;
        }

        internal int Value { get; }
    }
    
    internal class ValueToChannelArgs
    {
        public ValueToChannelArgs(ushort startAddress, object value)
        {
            StartAddress = startAddress;
            Value = value;
        }

        public ushort StartAddress { get; }
        public object Value { get; }
    }
}