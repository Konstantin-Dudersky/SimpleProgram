using System;
using Microsoft.EntityFrameworkCore;

namespace SimpleProgram.Lib.Archives
{
    public enum Providers
    {
        PostgreSql = 1
    }

    public class Archive : ITagArchive
    {
        public string ArchiveName { get; set; } = "Archive";

        private string ConnectionString { get; set; }
        private ITagArchive Context { get; set; }
        private Providers Provider { get; set; } = Providers.PostgreSql;

        public void SetProvider<TContext>(Providers provider, string connectionString) where TContext : DbContext
        {
            Provider = provider;
            ConnectionString = connectionString;

            var optionsBuilder = new DbContextOptionsBuilder<TContext>();

            switch (Provider)
            {
                case Providers.PostgreSql:
                    optionsBuilder.UseNpgsql(ConnectionString);
                    break;

                default:
                    throw new Exception("Не задан провайдер подключения к БД");
            }

            Context = (ITagArchive) Activator.CreateInstance(typeof(TContext), optionsBuilder.Options);
        }

        #region ITagArchive

        public TimeSeries GetTimeSeries(string name, DateTime dateTimeFrom, DateTime dateTimeTo)
        {
            return Context.GetTimeSeries(name, dateTimeFrom, dateTimeTo);
        }

        #endregion
    }
}