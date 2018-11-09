using System;
using System.ComponentModel;
using System.Globalization;
using SimpleProgram.Lib.Archives;
using SimpleProgram.Lib.OpcUa;

namespace SimpleProgram.Lib.Tag
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

        public TimeSeries GetTimeSeries(SimplifyType simplifyType = SimplifyType.None, int simplifyTime = 3600)
        {
            if (_derivedFunc == null)
                return Archive.GetTimeSeries(ArchiveTagId).Simplify(simplifyType, simplifyTime);

            return _derivedFunc(
                _derivedTag1?.GetTimeSeries(SimplifyType.Increment, 3600),
                _derivedTag2?.GetTimeSeries(SimplifyType.Increment, 3600),
                _derivedTag3?.GetTimeSeries(SimplifyType.Increment, 3600),
                _derivedTag4?.GetTimeSeries(SimplifyType.Increment, 3600),
                _derivedTag5?.GetTimeSeries(SimplifyType.Increment, 3600),
                _derivedTag6?.GetTimeSeries(SimplifyType.Increment, 3600),
                _derivedTag7?.GetTimeSeries(SimplifyType.Increment, 3600),
                _derivedTag8?.GetTimeSeries(SimplifyType.Increment, 3600),
                _derivedTag9?.GetTimeSeries(SimplifyType.Increment, 3600),
                _derivedTag10?.GetTimeSeries(SimplifyType.Increment, 3600));
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

        #region ConfDerivedFromTags

        private ITag _derivedTag1;
        private ITag _derivedTag2;
        private ITag _derivedTag3;
        private ITag _derivedTag4;
        private ITag _derivedTag5;
        private ITag _derivedTag6;
        private ITag _derivedTag7;
        private ITag _derivedTag8;
        private ITag _derivedTag9;
        private ITag _derivedTag10;

        private Func<TimeSeries, TimeSeries, TimeSeries, TimeSeries, TimeSeries, TimeSeries, TimeSeries, TimeSeries,
            TimeSeries, TimeSeries, TimeSeries> _derivedFunc;

        public void ConfDerivedFromTags(
            Func<TimeSeries, TimeSeries, TimeSeries, TimeSeries, TimeSeries, TimeSeries, TimeSeries, TimeSeries,
                TimeSeries, TimeSeries, TimeSeries> func,
            ITag tag1 = null,
            ITag tag2 = null,
            ITag tag3 = null,
            ITag tag4 = null,
            ITag tag5 = null,
            ITag tag6 = null,
            ITag tag7 = null,
            ITag tag8 = null,
            ITag tag9 = null,
            ITag tag10 = null)
        {
            _derivedFunc = func;
            _derivedTag1 = tag1;
            _derivedTag2 = tag2;
            _derivedTag3 = tag3;
            _derivedTag4 = tag4;
            _derivedTag5 = tag5;
            _derivedTag6 = tag6;
            _derivedTag7 = tag7;
            _derivedTag8 = tag8;
            _derivedTag9 = tag9;
            _derivedTag10 = tag10;
        }

        #endregion
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