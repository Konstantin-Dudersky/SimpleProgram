using System;
using Microsoft.EntityFrameworkCore;

namespace SimpleProgram.Lib.Archives
{
    public enum Providers
    {
        PostgreSql = 1
    }

    public class Archive : IDbContext
    {
        private string ConnectionString { get; set; }
        private IDbContext Context { get; set; }
        private Providers Provider { get; set; } = Providers.PostgreSql;

        public string ArchiveName { get; set; } = "Archive";

        public TimeSeries GetTimeSeries(string name)
        {
            return Context.GetTimeSeries(name);
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

            Context = (IDbContext) Activator.CreateInstance(typeof(TContext), optionsBuilder.Options);
        }
    }
}