using System;
using SimpleProgram.Lib.Archives;

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
        
        bool InputValid { get; }
    }

    public interface ITag<T> : ITag
    {
        T Value { get; set; }

        ITag<TNew> Conv<TNew>() where TNew : IConvertible;
    }
        
}