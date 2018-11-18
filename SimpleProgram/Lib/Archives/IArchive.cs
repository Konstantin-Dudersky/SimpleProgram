using System;
using System.Threading.Tasks;

namespace SimpleProgram.Lib.Archives
{
    public interface IArchive
    {
        string ArchiveName { get; set; }
        
        void DeleteArchiveData(string name, DateTime begin, DateTime end, double lessThen, double moreThen);

        Task<TimeSeries> GetTimeSeriesAsync(string name, DateTime dateTimeFrom, DateTime dateTimeTo,
            double lessThen, double moreThen);

        Task<double> IncrementAsync(string name, DateTime begin, DateTime end);
    }
}