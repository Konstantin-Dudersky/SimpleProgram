using System;
using System.Threading.Tasks;
using SimpleProgram.Lib.Archives;
using SimpleProgram.Lib.OpcUa;

namespace SimpleProgram.Lib.Tag
{
    public interface ITag
    {
        #region Archive
    
        Task<TimeSeries> GetArchiveTimeSeriesAsync(DateTime begin, DateTime end, 
            SimplifyType simplifyType = SimplifyType.None, int simplifyTime = 3600,
            double lessThen = double.MaxValue, double moreThen = double.MinValue);

        void DeleteData(DateTime begin, DateTime end, double lessThen, double moreThen);

        Task<double> GetArchiveValueAsync(DateTime begin, DateTime end,
            SimplifyType simplifyType = SimplifyType.None);

        TagChannelArchive ChannelArchive { get; set; }
        
        #endregion
        
        string TagId { get; set; }
        string TagName { get; set; }
        

        T1 GetValue<T1>();
        void SetValue<T1>(T1 value);

        string ValueString { get; set; }
        
        Type GenericType { get; }
        DateTime TimeStamp { get; }
        
        TagChannelOpcUaClient ChannelOpcUaClient { get; }
    }

    public interface ITag<T> : ITag
    {
        T Value { get; set; }

        ITag<TNew> ConvertTo<TNew>() where TNew : IConvertible;
    }
        
}