using System;

namespace SimpleProgram.Lib.Archives
{
    public interface ITagArchive
    {
        TimeSeries GetTimeSeries(string name, DateTime dateTimeFrom, DateTime dateTimeTo);

        void DeleteArchiveData(string name, DateTime begin, DateTime end);

        double Increment(string name, DateTime begin, DateTime end);
        
        string ArchiveName { get; set; }
    }
}