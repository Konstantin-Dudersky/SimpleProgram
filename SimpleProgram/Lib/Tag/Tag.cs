using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Threading.Tasks;
using NCalc;
using SimpleProgram.Channels;
using SimpleProgram.Channels.DatabaseClient;
using SimpleProgram.Channels.ModbusTcpClient;
using SimpleProgram.Channels.OpcUaClient;
using SimpleProgram.Lib.Archives;
using SimpleProgram.Lib.Messages;

namespace SimpleProgram.Lib.Tag
{
    public sealed class Tag<T> : ITag<T>
        where T : IConvertible, IComparable
    {
        public Tag()
        {
            if (GenericType == typeof(double))
            {
                FormatString = "f3";
            }
        }

        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                OnChange?.Invoke();

                if (_newValueFromChannel != nameof(Channels.OpcUaClient.TagChannelOpcUaClient))
                    NewValueToChannelOpcUaClient?.Invoke(this, new TagExchangeWithChannelArgs(Value, TimeStamp));

                if (_newValueFromChannel != nameof(Channels.ModbusTcpClient.TagChannelModbusTcpClient))
                    NewValueToChannelModbusTcpClient?.Invoke(this, new TagExchangeWithChannelArgs(Value, TimeStamp));

                if (_newValueFromChannel != nameof(Channels.DatabaseClient.TagChannelDatabaseClient))
                    NewValueToChannelDatabaseClient?.Invoke(this, new TagExchangeWithChannelArgs(Value, TimeStamp));

                NewValueToChannelMessage?.Invoke(this, new TagExchangeWithChannelArgs(Value, TimeStamp));

                _newValueFromChannel = "";
            }
        }

        public string TagId { get; set; }
        public string TagName { get; set; }
        public DateTime TimeStamp { get; private set; }

        public ITag<TNew> ConvertTo<TNew>() where TNew : IConvertible, IComparable
        {
            return new TagLink<T, TNew>(this);
        }

        public async Task<TimeSeries> GetArchiveTimeSeriesAsync(DateTime begin, DateTime end,
            SimplifyType simplifyType = SimplifyType.None, int simplifyTime = 3600,
            double lessThen = double.MaxValue, double moreThen = double.MinValue)
        {
            if (_derivedFunc == null)
                return (await _historyManager.Get().GetTimeSeriesAsync(begin, end, lessThen, moreThen))
                    .Simplify(simplifyType, simplifyTime);

            var f = new Expression(_derivedFunc).ToLambda<ExpressionContext<TimeSeries>, TimeSeries>();

            var ts = new List<TimeSeries>();

            for (var i = 0; i < _derivedTags.Count; i++)
            {
                if (_derivedTags[i] == null)
                    ts.Add(new TimeSeries());
                else
                    ts.Add(await _derivedTags[i]
                        .GetArchiveTimeSeriesAsync(begin, end, _derivedSimplify[i], simplifyTime));
            }

            var context = new ExpressionContext<TimeSeries>
            {
                Tag1 = ts[0],
                Tag2 = ts[1],
                Tag3 = ts[2],
                Tag4 = ts[3],
                Tag5 = ts[4],
                Tag6 = ts[5],
                Tag7 = ts[6],
                Tag8 = ts[7],
                Tag9 = ts[8],
                Tag10 = ts[9]
            };
            return f(context);
        }

        public async Task<double> GetArchiveValueAsync(DateTime begin, DateTime end,
            SimplifyType simplifyType = SimplifyType.None)
        {
            if (_derivedFunc == null)
                return await _historyManager.Get().GetArchiveValueAsync(begin, end, simplifyType);

            var f = new Expression(_derivedFunc).ToLambda<ExpressionContext<double?>, double?>();

            var tagValues = new List<double>();

            for (var i = 0; i < _derivedTags.Count; i++)
            {
                if (_derivedTags[i] == null)
                    tagValues.Add(0);
                else
                    tagValues.Add(await _derivedTags[i].GetArchiveValueAsync(begin, end, _derivedSimplify[i]));
            }

            var context = new ExpressionContext<double?>
            {
                Tag1 = tagValues[0],
                Tag2 = tagValues[1],
                Tag3 = tagValues[2],
                Tag4 = tagValues[3],
                Tag5 = tagValues[4],
                Tag6 = tagValues[5],
                Tag7 = tagValues[6],
                Tag8 = tagValues[7],
                Tag9 = tagValues[8],
                Tag10 = tagValues[9]
            };
            return f(context) ?? 0;
        }

        public void DeleteData(DateTime begin, DateTime end, double lessThen, double moreThen)
        {
            _historyManager.Get().DeleteArchiveData(begin, end, lessThen, moreThen);
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

        public string FormatString { get; set; }

        public Type GenericType => typeof(T);


        #region events        

        public event Action OnChange;

        private string _newValueFromChannel;


        private void OnNewValueFromChannel(object sender, TagExchangeWithChannelArgs eventArgs)
        {
            _newValueFromChannel = sender.GetType().Name;
            SetValue(eventArgs.Value);
            TimeStamp = eventArgs.TimeStamp;
        }

        #endregion


        #region ConfDerivedFromTags

        private List<ITag> _derivedTags;
        private List<SimplifyType> _derivedSimplify;

        private string _derivedFunc;

        public void ConfDerivedFromTags(
            string func,
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
            _derivedTags = new List<ITag>
            {
                tag1,
                tag2,
                tag3,
                tag4,
                tag5,
                tag6,
                tag7,
                tag8,
                tag9,
                tag10
            };

            _derivedSimplify = new List<SimplifyType>
            {
                derivedSimplify1,
                derivedSimplify2,
                derivedSimplify3,
                derivedSimplify4,
                derivedSimplify5,
                derivedSimplify6,
                derivedSimplify7,
                derivedSimplify8,
                derivedSimplify9,
                derivedSimplify10
            };

            _derivedFunc = func;
        }

        #endregion


        #region TagChannelOpcUaClient

        public event EventHandler<TagExchangeWithChannelArgs> NewValueToChannelOpcUaClient;

        private TagChannelOpcUaClient _channelOpcUaClient;

        public TagChannelOpcUaClient TagChannelOpcUaClient
        {
            get => _channelOpcUaClient;
            set
            {
                _channelOpcUaClient = value;
                _channelOpcUaClient.NewValueFromChannel += OnNewValueFromChannel;
                NewValueToChannelOpcUaClient += _channelOpcUaClient.OnNewValueToChannel;

                _historyManager.Add(0, _channelOpcUaClient);
            }
        }

        #endregion


        #region TagChannelModbusTcpClient

        public event EventHandler<TagExchangeWithChannelArgs> NewValueToChannelModbusTcpClient;

        private TagChannelModbusTcpClient _channelModbusTcpClient;

        public TagChannelModbusTcpClient TagChannelModbusTcpClient
        {
            get => _channelModbusTcpClient;
            set
            {
                _channelModbusTcpClient = value;
                _channelModbusTcpClient.NewValueFromChannel += OnNewValueFromChannel;
                NewValueToChannelModbusTcpClient += TagChannelModbusTcpClient.OnNewValueToChannel;
            }
        }

        #endregion


        #region TagChannelDatabaseClient

        public event EventHandler<TagExchangeWithChannelArgs> NewValueToChannelDatabaseClient;

        private TagChannelDatabaseClient _channelDatabaseClient;

        public TagChannelDatabaseClient TagChannelDatabaseClient
        {
            get => _channelDatabaseClient;
            set
            {
                _channelDatabaseClient = value;
                _historyManager.Add(1, _channelDatabaseClient);
                _channelDatabaseClient.NewValueFromChannel += OnNewValueFromChannel;
                // to channel
            }
        }

        #endregion


        #region Message

        public event EventHandler<TagExchangeWithChannelArgs> NewValueToChannelMessage;

        private Dictionary<string, Message<T>> _messages;

        public Dictionary<string, Message<T>> Messages
        {
            get => _messages;
            set
            {
                _messages = value;
                foreach (var message in _messages)
                {
                    NewValueToChannelMessage += message.Value.OnNewValueToChannel;
                }
            }
        }

        #endregion


        [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
        private class ExpressionContext<TExpr>
        {
            public TExpr Tag1 { get; set; }
            public TExpr Tag2 { get; set; }
            public TExpr Tag3 { get; set; }
            public TExpr Tag4 { get; set; }
            public TExpr Tag5 { get; set; }
            public TExpr Tag6 { get; set; }
            public TExpr Tag7 { get; set; }
            public TExpr Tag8 { get; set; }
            public TExpr Tag9 { get; set; }
            public TExpr Tag10 { get; set; }
        }

        private readonly TagChannelHistoryManager _historyManager = new TagChannelHistoryManager();

        public override string ToString()
        {
            if (FormatString == "")
                return Value.ToString(CultureInfo.InvariantCulture);

            switch (FormatString[0])
            {
                case 'F':
                case 'f':
                    var value = GetValue<double>();
                    return value.ToString(FormatString);

                default:
                    Console.WriteLine("Неизвестный формат");
                    return Value.ToString(CultureInfo.InvariantCulture);
            }
        }

        private class TagChannelHistoryManager
        {
            private readonly List<TagChannelHistoryManagerItem> _items = new List<TagChannelHistoryManagerItem>();
            private int _maxOrder;

            internal void Add(int order, ITagChannelHistory tagChannelHistory)
            {
                _items.Add(new TagChannelHistoryManagerItem(order, tagChannelHistory));

                if (order > _maxOrder) _maxOrder = order;
            }

            internal ITagChannelHistory Get()
            {
                if (_items.Count <= 0)
                    throw new Exception("В теге не определено ни одного архива");

                var currentOrder = 0;
                while (true)
                {
                    foreach (var item in _items)
                    {
                        if (item.Order == currentOrder)
                            return item.TagChannelHistory;
                    }

                    currentOrder++;
                }
            }

            private struct TagChannelHistoryManagerItem
            {
                public readonly int Order;
                public readonly ITagChannelHistory TagChannelHistory;

                public TagChannelHistoryManagerItem(int order, ITagChannelHistory tagChannelHistory)
                {
                    Order = order;
                    TagChannelHistory = tagChannelHistory;
                }
            }
        }
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