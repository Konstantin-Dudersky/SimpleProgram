using System;
using System.ComponentModel;
using System.Globalization;
using SimpleProgram.Lib.Archives;
using SimpleProgram.Lib.OpcUa;

namespace SimpleProgram.Lib
{
    public sealed class Tag<T> : ITag<T>
        where T : IConvertible
    {
        private TagOpcUaClient _opcUaClient;
        private T _value;

        public TagOpcUaClient OpcUaClient
        {
            get => _opcUaClient;
            set
            {
                _opcUaClient = value;
                _opcUaClient.NewValueFromChannel += OnNewValueFromChannel;
                NewValueToChannel += _opcUaClient.OnNewValueToChannel;
            }
        }

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                OnChange?.Invoke();
                NewValueToChannel?.Invoke(this, new TagExchangeWithChannelArgs(Value, DateTime.Now));
            }
        }

        public Archive Archive { get; set; }
        public string ArchiveTagId { get; set; }
        public string TagId { get; set; }
        public string TagName { get; set; }
        public DateTime TimeStamp { get; private set; }


        public ITag<TNew> ConvertTo<TNew>() where TNew : IConvertible
        {
            return new TagLink<T, TNew>(this);
        }

        public TimeSeries GetTimeSeries()
        {
            return Archive.GetTimeSeries(ArchiveTagId);
        }

        public T1 GetValue<T1>()
        {
            return (T1) Convert.ChangeType(Value, typeof(T1));
        }

        public void SetValue<T1>(T1 value)
        {
            Value = (T) Convert.ChangeType(value, typeof(T));
        }

        public string ValueString
        {
            get => Value.ToString(CultureInfo.InvariantCulture);
            set
            {
                T fromString;
                try
                {
                    fromString = (T) TypeDescriptor.GetConverter(typeof(T)).ConvertFromString(value);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    fromString = Value;
                }

                Value = fromString;
            }
        }

        public Type GenericType => typeof(T);

        private void OnNewValueFromChannel(object sender, TagExchangeWithChannelArgs eventArgs)
        {
            SetValue(eventArgs.Value);
            TimeStamp = eventArgs.TimeStamp;
        }

        public event Action OnChange;
        public event EventHandler<TagExchangeWithChannelArgs> NewValueToChannel;

    }

    public class TagExchangeWithChannelArgs : EventArgs
    {
        public TagExchangeWithChannelArgs(object value, DateTime timeStamp)
        {
            Value = value;
            TimeStamp = timeStamp;
        }

        public object Value { get; }
        public DateTime TimeStamp { get; }
    }
}