using System;
using System.Threading.Tasks;

namespace SimpleProgram.Lib.Archives
{
    public class TagChannelArchive
    {
        public TagChannelArchive(IArchive archive, string id)
        {
            Archive = archive;
            Id = id;
        }

        public IArchive Archive { get; }
        public string Id { get; }

        internal async Task<TimeSeries> GetArchiveTimeSeriesAsync(DateTime begin, DateTime end, double lessThen,
            double moreThen)
        {
            return await Archive.GetTimeSeriesAsync(Id, begin, end, lessThen, moreThen);
        }

        internal async Task<double> GetArchiveValueAsync(DateTime begin, DateTime end,
            SimplifyType simplifyType)
        {
            return await Archive.GetArchiveValueAsync(Id, begin, end, simplifyType);
        }

        internal void DeleteArchiveData(DateTime begin, DateTime end, double lessThen, double moreThen)
        {
            Archive.DeleteArchiveData(Id, begin, end, lessThen, moreThen);
        }
    }
}