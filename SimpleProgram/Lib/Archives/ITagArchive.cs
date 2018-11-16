using System;

namespace SimpleProgram.Lib.Archives
{
    public interface ITagArchive
    {
        TimeSeries GetTimeSeries(string name, DateTime dateTimeFrom, DateTime dateTimeTo,
            double lessThen, double moreThen);

        void DeleteArchiveData(string name, DateTime begin, DateTime end, double lessThen, double moreThen);

        double Increment(string name, DateTime begin, DateTime end);
        
        string ArchiveName { get; set; }
    }
}