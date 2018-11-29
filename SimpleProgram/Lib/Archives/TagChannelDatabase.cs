using System;
using System.Threading.Tasks;

namespace SimpleProgram.Lib.Archives
{
    public class TagChannelDatabase : ITagChannelHistory
    {
        public TagChannelDatabase(IDatabase archive, string id)
        {
            Archive = archive;
            Id = id;
        }

        public IDatabase Archive { get; }
        public string Id { get; }


        #region ITagChannelHistory

        public async Task<TimeSeries> GetTimeSeriesAsync(DateTime dateTimeFrom, DateTime dateTimeTo,
            double lessThen, double moreThen)
        {
            TimeSeries data;

            using (var context = Archive.GetDbContext())
            {
                data = await ((IDatabaseInterop) context).GetTimeSeriesAsync(Id, dateTimeFrom, dateTimeTo, lessThen,
                    moreThen);
            }

            return data;
        }


        public void DeleteArchiveData(DateTime begin, DateTime end, double lessThen, double moreThen)
        {
            using (var context = Archive.GetDbContext())
            {
                var entities = ((IDatabaseInterop) context).GetEntitiesAsync(Id, begin, end, lessThen, moreThen);
                context.RemoveRange(entities);
                context.SaveChanges();
            }
        }

        public async Task<double> GetArchiveValueAsync(DateTime begin, DateTime end,
            SimplifyType simplifyType = SimplifyType.None)
        {
            using (var context = Archive.GetDbContext())
            {
                return await ((IDatabaseInterop) context).GetArchiveValueAsync(Id, begin, end, simplifyType);
            }
        }

        #endregion
    }
}