using System;

namespace SimpleProgram.Lib.Archives
{
    public interface ITagArchive
    {
        TimeSeries GetTimeSeries(string name, DateTime dateTimeFrom, DateTime dateTimeTo);
    }
}