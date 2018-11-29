using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SimpleProgram.Lib.Archives
{
    public enum Providers
    {
        PostgreSql = 1
    }

    public class Archive<TCont> : IHistory
        where TCont : DbContext
    {
        private readonly DbContextOptionsBuilder<TCont> _optionsBuilder;

        private readonly Type _type;


        public Archive(Providers provider, string connectionString)
        {
            ConnectionString = connectionString;
            Provider = provider;

            _optionsBuilder = new DbContextOptionsBuilder<TCont>();

            switch (provider)
            {
                case Providers.PostgreSql:
                    _optionsBuilder.UseNpgsql(connectionString);
                    break;

                default:
                    throw new Exception("Не задан провайдер подключения к БД");
            }

            _type = typeof(TCont);
        }

        public string ArchiveName { get; set; } = "Archive";

        public string ConnectionString { get; }
        public Providers Provider { get; }

        #region IHistory

        public async Task<TimeSeries> GetTimeSeriesAsync(string name, DateTime dateTimeFrom, DateTime dateTimeTo,
            double lessThen, double moreThen)
        {
            TimeSeries data;

            using (var context = (DbContext) Activator.CreateInstance(_type, _optionsBuilder.Options))
            {
                data = await ((IDatabaseInterop) context).GetTimeSeriesAsync(name, dateTimeFrom, dateTimeTo, lessThen,
                    moreThen);
            }

            return data;
        }

        public void DeleteArchiveData(string name, DateTime begin, DateTime end, double lessThen, double moreThen)
        {
            using (var context = (DbContext) Activator.CreateInstance(_type, _optionsBuilder.Options))
            {
                var entities = ((IDatabaseInterop) context).GetEntitiesAsync(name, begin, end, lessThen, moreThen);
                context.RemoveRange(entities);
                context.SaveChanges();
            }
        }

        public async Task<double> GetArchiveValueAsync(string name, DateTime begin, DateTime end,
            SimplifyType simplifyType = SimplifyType.None)
        {
            using (var context = (DbContext) Activator.CreateInstance(_type, _optionsBuilder.Options))
            {
                return await ((IDatabaseInterop) context).GetArchiveValueAsync(name, begin, end, simplifyType);
            }
        }

        #endregion
    }
}