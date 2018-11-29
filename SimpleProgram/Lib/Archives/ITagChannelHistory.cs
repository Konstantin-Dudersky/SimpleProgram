using System;
using System.Threading.Tasks;

namespace SimpleProgram.Lib.Archives
{
    public interface ITagChannelHistory
    {
        void DeleteArchiveData(DateTime begin, DateTime end, double lessThen, double moreThen);

        Task<TimeSeries> GetTimeSeriesAsync(DateTime dateTimeFrom, DateTime dateTimeTo,
            double lessThen, double moreThen);

        Task<double> GetArchiveValueAsync(DateTime begin, DateTime end,
            SimplifyType simplifyType = SimplifyType.None);
    }
}