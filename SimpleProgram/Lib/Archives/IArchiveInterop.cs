using System;
using System.Threading.Tasks;

namespace SimpleProgram.Lib.Archives
{
    internal interface IArchiveInterop
    {
        Task<TimeSeries> GetTimeSeriesAsync(string name, DateTime dateTimeFrom, DateTime dateTimeTo,
            double lessThen, double moreThen);
        
        Task<object[]> GetEntitiesAsync(string name, DateTime begin, DateTime end, double lessThen, double moreThen);

        Task<double> GetArchiveValueAsync(string name, DateTime begin, DateTime end,
            SimplifyType simplifyType = SimplifyType.None);
    }
}