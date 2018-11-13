using System;
using Microsoft.EntityFrameworkCore;

namespace SimpleProgram.Lib.Archives
{
    public enum Providers
    {
        PostgreSql = 1
    }

    public class Archive<TCont> : ITagArchive
        where TCont: DbContext
    {
        public string ArchiveName { get; set; } = "Archive";

        private string ConnectionString { get; set; }
        private ITagArchive Context { get; set; }
        private Providers Provider { get; set; } = Providers.PostgreSql;

        private Type type;
        private DbContextOptionsBuilder<TCont> _optionsBuilder;
        

        public Archive(Providers provider, string connectionString)
        {
            _optionsBuilder = new DbContextOptionsBuilder<TCont>();
            
            switch (provider)
            {
                case Providers.PostgreSql:
                    _optionsBuilder.UseNpgsql(connectionString);
                    break;

                default:
                    throw new Exception("Не задан провайдер подключения к БД");
            }
            
            type = typeof(TCont);
        }

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

//            Context = (ITagArchive) Activator.CreateInstance(typeof(TContext), optionsBuilder.Options);
        }

        #region ITagArchive

        public TimeSeries GetTimeSeries(string name, DateTime dateTimeFrom, DateTime dateTimeTo)
        {
            TimeSeries data;

            using (var context = (DbContext) Activator.CreateInstance(type, _optionsBuilder.Options))
            {
                data =  ((ITagArchive) context).GetTimeSeries(name, dateTimeFrom, dateTimeTo);
            }

            return data;
        }

        #endregion
    }
}