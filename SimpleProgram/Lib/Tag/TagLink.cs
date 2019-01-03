using System;
using System.Threading.Tasks;
using SimpleProgram.Channels.DatabaseClient;
using SimpleProgram.Channels.ModbusTcpClient;
using SimpleProgram.Channels.OpcUaClient;
using SimpleProgram.Lib.Archives;

namespace SimpleProgram.Lib.Tag
{
    public class TagLink<TOld, TNew> : ITag<TNew>
        where TNew : IConvertible, IComparable
        where TOld : IConvertible, IComparable
    {
        private readonly Tag<TOld> _tagLink;

        public TagLink(Tag<TOld> tagLink)
        {
            _tagLink = tagLink;
        }

        public TNew Value
        {
            get => (TNew) Convert.ChangeType(_tagLink.Value, typeof(TNew));
            set => _tagLink.Value = (TOld) Convert.ChangeType(value, typeof(TOld));
        }

        public Task<double> GetArchiveValueAsync(DateTime begin, DateTime end,
            SimplifyType simplifyType = SimplifyType.None)
        {
            return _tagLink.GetArchiveValueAsync(begin, end);
        }

        public TagChannelDatabaseClient TagChannelDatabaseClient
        {
            get => _tagLink.TagChannelDatabaseClient;
            set => _tagLink.TagChannelDatabaseClient = value;
        }

        public string TagId
        {
            get => _tagLink.TagId;
            set => _tagLink.TagId = value;
        }

        public string TagName
        {
            get => _tagLink.TagName;
            set => _tagLink.TagName = value;
        }

        public ITag<TNew1> ConvertTo<TNew1>() where TNew1 : IConvertible, IComparable
        {
            return _tagLink.ConvertTo<TNew1>();
        }

        public Task<TimeSeries> GetArchiveTimeSeriesAsync(DateTime begin, DateTime end,
            SimplifyType simplifyType = SimplifyType.None, int simplifyTime = 3600,
            double lessThen = double.MaxValue, double moreThen = double.MinValue)
        {
            return _tagLink.GetArchiveTimeSeriesAsync(begin, end, simplifyType, simplifyTime, lessThen, moreThen);
        }

        public Task<double> GetValueAsync(DateTime begin, DateTime end, SimplifyType simplifyType = SimplifyType.None,
            int simplifyTime = 3600)
        {
            throw new NotImplementedException();
        }

        public void DeleteData(DateTime begin, DateTime end, double lessThen, double moreThen)
        {
            _tagLink.DeleteData(begin, end, lessThen, moreThen);
        }

        public T1 GetValue<T1>()
        {
            return _tagLink.GetValue<T1>();
        }

        public void SetValue<T1>(T1 value)
        {
            _tagLink.SetValue(value);
        }

        public string ValueString
        {
            get => _tagLink.ValueString;
            set => _tagLink.ValueString = value;
        }

        public string FormatString
        {
            get => _tagLink.FormatString;
            set => _tagLink.FormatString = value;
        }

        public Type GenericType => typeof(TNew);
        public DateTime TimeStamp => _tagLink.TimeStamp;

        public TagChannelOpcUaClient TagChannelOpcUaClient
        {
            get => _tagLink.TagChannelOpcUaClient;
            set => _tagLink.TagChannelOpcUaClient = value;
        }

        public TagChannelModbusTcpClient TagChannelModbusTcpClient
        {
            get => _tagLink.TagChannelModbusTcpClient;
            set => _tagLink.TagChannelModbusTcpClient = value;
        }
    }
}