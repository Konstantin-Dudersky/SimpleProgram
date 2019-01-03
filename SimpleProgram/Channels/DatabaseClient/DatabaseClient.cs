using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using SimpleProgram.Lib.Archives;

namespace SimpleProgram.Channels.DatabaseClient
{
    public enum Providers
    {
        PostgreSql = 1
    }

    public class DatabaseClient<T> : ChannelBase, IDatabaseClient
        where T : DbContext
    {
        private const int minSamplingInterval = 1000;
        
        private readonly List<MonitoredItem> _items = new List<MonitoredItem>();

        private int _currRelSamplingInterval = 1;
        private int _maxRelSamplingInterval;
        
        private readonly DbContextOptionsBuilder<T> _optionsBuilder;

        private readonly Type _type;
        
        // ReSharper disable once NotAccessedField.Local
        private readonly Timer _timerCyclicRead;


        public DatabaseClient(Providers provider, string connectionString) : base("test database channel", false)
        {
            ConnectionString = connectionString;
            Provider = provider;

            _optionsBuilder = new DbContextOptionsBuilder<T>();

            switch (provider)
            {
                case Providers.PostgreSql:
                    _optionsBuilder.UseNpgsql(connectionString);
                    break;

                default:
                    throw new Exception("Не задан провайдер подключения к БД");
            }

            _type = typeof(T);
            
            _timerCyclicRead = new Timer(TimerCyclicRead, null, 0, minSamplingInterval);
        }

        public string ArchiveName { get; set; } = "Archive";

        public string ConnectionString { get; }
        public Providers Provider { get; }


        public DbContext GetDbContext()
        {
            return (DbContext) Activator.CreateInstance(_type, _optionsBuilder.Options);
        }
        
        public void AddMonitoredItem(TagChannelDatabaseClient client, string id, int samplingInterval, 
            EventHandler<ValueFromChannelArgs> eventHandler)
        {
            if (samplingInterval == 0) return; 
            
            var relSamplingInterval = (int) Math.Ceiling((double) samplingInterval / minSamplingInterval);

            _maxRelSamplingInterval = Math.Max(_maxRelSamplingInterval, relSamplingInterval);
            
            var item = new MonitoredItem(id, relSamplingInterval);
            item.OnNewValueFromChannel += eventHandler;
            _items.Add(item);
        }
        
        private async void TimerCyclicRead(object obj)
        {
            foreach (var item in _items)
            {
                if (item.RelSamplingInterval > _currRelSamplingInterval) continue;
                
                try
                {
                    double value;
                    using (var context = GetDbContext())
                    {
                        value = await ((IDatabaseInterop) context).GetArchiveValueAsync(item.Id, 
                            DateTime.MinValue, DateTime.MaxValue, SimplifyType.Last);
                    }

                    item.NewValueFromChannel(value);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            _currRelSamplingInterval++;
            if (_currRelSamplingInterval > _maxRelSamplingInterval)
                _currRelSamplingInterval = 1;
        }
        
        private class MonitoredItem
        {
            internal event EventHandler<ValueFromChannelArgs> OnNewValueFromChannel;
            internal string Id { get; }
            internal int RelSamplingInterval { get; }
            
            public MonitoredItem(string id, int relSamplingInterval)
            {
                Id = id;
                RelSamplingInterval = relSamplingInterval;
            }

            internal void NewValueFromChannel(double value)
            {
                OnNewValueFromChannel?.Invoke(this, new ValueFromChannelArgs(value));
            }
        }
    }

    public class ValueFromChannelArgs
    {
        public ValueFromChannelArgs(double value)
        {
            Value = value;
        }

        internal double Value { get; }
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