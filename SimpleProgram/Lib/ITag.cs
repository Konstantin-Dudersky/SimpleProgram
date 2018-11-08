using System;
using SimpleProgram.Lib.Archives;
using SimpleProgram.Lib.OpcUa;

namespace SimpleProgram.Lib
{
    public interface ITag
    {
        Archive Archive { get; set; }
        string ArchiveTagId { get; set; }
        string TagId { get; set; }
        string TagName { get; set; }
        TimeSeries GetTimeSeries();

        T1 GetValue<T1>();
        void SetValue<T1>(T1 value);

        string ValueString { get; set; }
        
        Type GenericType { get; }
        DateTime TimeStamp { get; }
        
        TagOpcUaClient OpcUaClient { get; set; }
    }

    public interface ITag<T> : ITag
    {
        T Value { get; set; }

        ITag<TNew> ConvertTo<TNew>() where TNew : IConvertible;
    }
        
}