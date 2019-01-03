using System;
using System.Threading.Tasks;
using SimpleProgram.Lib.Archives;
using SimpleProgram.Lib.Tag;

namespace SimpleProgram.Channels.DatabaseClient
{
    public class TagChannelDatabaseClient : ITagChannelHistory
    {
        public TagChannelDatabaseClient(IDatabaseClient archive, string id, int samplingInterval)
        {
            Archive = archive;
            Id = id;
            
            archive.AddMonitoredItem(this, id, samplingInterval, OnNewValueFromChannel);
        }

        public IDatabaseClient Archive { get; }
        public string Id { get; }

        private void OnNewValueFromChannel(object sender, ValueFromChannelArgs e)
        {
            NewValueFromChannel?.Invoke(this, new TagExchangeWithChannelArgs(e.Value, DateTime.Now));
        }
        
        public event EventHandler<TagExchangeWithChannelArgs> NewValueFromChannel;

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

        public async void DeleteArchiveData(DateTime begin, DateTime end, double lessThen, double moreThen)
        {
            using (var context = Archive.GetDbContext())
            {
                var entities = await ((IDatabaseInterop) context).GetEntitiesAsync(Id, begin, end, lessThen, moreThen);
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