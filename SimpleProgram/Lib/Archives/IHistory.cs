using System;
using System.Threading.Tasks;

namespace SimpleProgram.Lib.Archives
{
    public interface IHistory
    {
        string ArchiveName { get; set; }
        string ConnectionString { get; }
        Providers Provider { get; }

        void DeleteArchiveData(string name, DateTime begin, DateTime end, double lessThen, double moreThen);

        Task<TimeSeries> GetTimeSeriesAsync(string name, DateTime dateTimeFrom, DateTime dateTimeTo,
            double lessThen, double moreThen);

        Task<double> GetArchiveValueAsync(string name, DateTime begin, DateTime end,
            SimplifyType simplifyType = SimplifyType.None);
    }
}