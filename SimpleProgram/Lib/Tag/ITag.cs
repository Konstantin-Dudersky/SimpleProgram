using System;
using SimpleProgram.Lib.Archives;
using SimpleProgram.Lib.OpcUa;

namespace SimpleProgram.Lib.Tag
{
    public interface ITag
    {
        #region Archive
        
        IArchive Archive { get; set; }
        string ArchiveTagId { get; set; }
        
        TimeSeries GetTimeSeries(DateTime begin, DateTime end, 
            SimplifyType simplifyType = SimplifyType.None, int simplifyTime = 3600,
            double lessThen = double.MaxValue, double moreThen = double.MinValue);
        
        void DeleteData(DateTime begin, DateTime end, double lessThen, double moreThen);

        double Increment(DateTime begin, DateTime end);
        
        #endregion
        
        string TagId { get; set; }
        string TagName { get; set; }
        

        T1 GetValue<T1>();
        void SetValue<T1>(T1 value);

        string ValueString { get; set; }
        
        Type GenericType { get; }
        DateTime TimeStamp { get; }
        
        TagOpcUaClient OpcUaClient { get; }
    }

    public interface ITag<T> : ITag
    {
        T Value { get; set; }

        ITag<TNew> ConvertTo<TNew>() where TNew : IConvertible;
    }
        
}