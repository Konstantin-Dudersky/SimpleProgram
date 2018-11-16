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
        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                OnChange?.Invoke();

                if (_newValueFromChannel != nameof(TagOpcUaClient))
                    NewValueToChannelOpcUaClient?.Invoke(this, new TagExchangeWithChannelArgs(Value, DateTime.Now));

                _newValueFromChannel = "";
            }
        }

        public ITagArchive Archive { get; set; }
        public string ArchiveTagId { get; set; }
        public string TagId { get; set; }
        public string TagName { get; set; }
        public DateTime TimeStamp { get; private set; }


        public ITag<TNew> ConvertTo<TNew>() where TNew : IConvertible
        {
            return new TagLink<T, TNew>(this);
        }

        public TimeSeries GetTimeSeries(DateTime begin, DateTime end, SimplifyType simplifyType = SimplifyType.None, int simplifyTime = 3600,
            double lessThen = double.MaxValue, double moreThen = double.MinValue)
        {
            if (_derivedFunc == null)
                return Archive.GetTimeSeries(ArchiveTagId, begin, end, lessThen, moreThen).Simplify(simplifyType, simplifyTime);

            return _derivedFunc(
                _derivedTag1?.GetTimeSeries(begin, end, _derivedSimplify1, simplifyTime),
                _derivedTag2?.GetTimeSeries(begin, end, _derivedSimplify2, simplifyTime),
                _derivedTag3?.GetTimeSeries(begin, end, _derivedSimplify3, simplifyTime),
                _derivedTag4?.GetTimeSeries(begin, end, _derivedSimplify4, simplifyTime),
                _derivedTag5?.GetTimeSeries(begin, end, _derivedSimplify5, simplifyTime),
                _derivedTag6?.GetTimeSeries(begin, end, _derivedSimplify6, simplifyTime),
                _derivedTag7?.GetTimeSeries(begin, end, _derivedSimplify7, simplifyTime),
                _derivedTag8?.GetTimeSeries(begin, end, _derivedSimplify8, simplifyTime),
                _derivedTag9?.GetTimeSeries(begin, end, _derivedSimplify9, simplifyTime),
                _derivedTag10?.GetTimeSeries(begin, end, _derivedSimplify10, simplifyTime));
        }

        public void DeleteData(DateTime begin, DateTime end, double lessThen, double moreThen)
        {
            Archive.DeleteArchiveData(ArchiveTagId, begin, end, lessThen, moreThen);
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

        
        
        #region events        

        public event Action OnChange;

        private string _newValueFromChannel;
        public event EventHandler<TagExchangeWithChannelArgs> NewValueToChannelOpcUaClient;

        private void OnNewValueFromChannel(object sender, TagExchangeWithChannelArgs eventArgs)
        {
            _newValueFromChannel = sender.GetType().Name;
            SetValue(eventArgs.Value);
            TimeStamp = eventArgs.TimeStamp;
        }

        #endregion

        
        
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
        private SimplifyType _derivedSimplify1;
        private SimplifyType _derivedSimplify2;
        private SimplifyType _derivedSimplify3;
        private SimplifyType _derivedSimplify4;
        private SimplifyType _derivedSimplify5;
        private SimplifyType _derivedSimplify6;
        private SimplifyType _derivedSimplify7;
        private SimplifyType _derivedSimplify8;
        private SimplifyType _derivedSimplify9;
        private SimplifyType _derivedSimplify10;

        private Func<TimeSeries, TimeSeries, TimeSeries, TimeSeries, TimeSeries, TimeSeries, TimeSeries, TimeSeries,
            TimeSeries, TimeSeries, TimeSeries> _derivedFunc;

        public void ConfDerivedFromTags(
            Func<TimeSeries, TimeSeries, TimeSeries, TimeSeries, TimeSeries, TimeSeries, TimeSeries, TimeSeries,
                TimeSeries, TimeSeries, TimeSeries> func,
            ITag tag1 = null, SimplifyType derivedSimplify1 = SimplifyType.Increment,
            ITag tag2 = null, SimplifyType derivedSimplify2 = SimplifyType.Increment,
            ITag tag3 = null, SimplifyType derivedSimplify3 = SimplifyType.Increment,
            ITag tag4 = null, SimplifyType derivedSimplify4 = SimplifyType.Increment,
            ITag tag5 = null, SimplifyType derivedSimplify5 = SimplifyType.Increment,
            ITag tag6 = null, SimplifyType derivedSimplify6 = SimplifyType.Increment,
            ITag tag7 = null, SimplifyType derivedSimplify7 = SimplifyType.Increment,
            ITag tag8 = null, SimplifyType derivedSimplify8 = SimplifyType.Increment,
            ITag tag9 = null, SimplifyType derivedSimplify9 = SimplifyType.Increment,
            ITag tag10 = null, SimplifyType derivedSimplify10 = SimplifyType.Increment)
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
            _derivedSimplify1 = derivedSimplify1;
            _derivedSimplify2 = derivedSimplify2;
            _derivedSimplify3 = derivedSimplify3;
            _derivedSimplify4 = derivedSimplify4;
            _derivedSimplify5 = derivedSimplify5;
            _derivedSimplify6 = derivedSimplify6;
            _derivedSimplify7 = derivedSimplify7;
            _derivedSimplify8 = derivedSimplify8;
            _derivedSimplify9 = derivedSimplify9;
            _derivedSimplify10 = derivedSimplify10;
        }

        #endregion

        
        
        #region ConfOpcUaClient

        public TagOpcUaClient OpcUaClient { get; private set; }

        public void ConfOpcUaClient(OpcUaClient client, string nodeId, int samplingInterval)
        {
            OpcUaClient = new TagOpcUaClient(client, nodeId, samplingInterval);
            OpcUaClient.NewValueFromChannel += OnNewValueFromChannel;
            NewValueToChannelOpcUaClient += OpcUaClient.OnNewValueToChannel;
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