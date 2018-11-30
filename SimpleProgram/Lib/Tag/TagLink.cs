using System;
using System.Threading.Tasks;
using SimpleProgram.Lib.Archives;
using SimpleProgram.Lib.Modbus;
using SimpleProgram.Lib.OpcUa;

namespace SimpleProgram.Lib.Tag
{
    public class TagLink<TOld, TNew> : ITag<TNew>
        where TNew : IConvertible
        where TOld : IConvertible
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

        public TagChannelDatabase ChannelDatabase
        {
            get => _tagLink.ChannelDatabase;
            set => _tagLink.ChannelDatabase = value;
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

        public ITag<TNew1> ConvertTo<TNew1>() where TNew1 : IConvertible
        {
            return _tagLink.ConvertTo<TNew1>();
        }

        public Task<TimeSeries> GetArchiveTimeSeriesAsync(DateTime begin, DateTime end, SimplifyType simplifyType = SimplifyType.None, int simplifyTime = 3600,
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

        public Type GenericType => typeof(TNew);
        public DateTime TimeStamp => _tagLink.TimeStamp;
        public TagChannelOpcUaClient ChannelOpcUaClient { get; set; }
        public TagChannelModbusTcpClient ChannelModbusTcpClient { get; }
    }
}