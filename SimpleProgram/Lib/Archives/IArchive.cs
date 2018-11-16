using System;

namespace SimpleProgram.Lib.Archives
{
    public interface IArchive
    {
        string ArchiveName { get; set; }
        
        void DeleteArchiveData(string name, DateTime begin, DateTime end, double lessThen, double moreThen);

        TimeSeries GetTimeSeries(string name, DateTime dateTimeFrom, DateTime dateTimeTo,
            double lessThen, double moreThen);

        double Increment(string name, DateTime begin, DateTime end);
    }
}