using Microsoft.EntityFrameworkCore;
using System;

namespace SimpleProgram.Lib.Archives
{
    public enum Providers
    {
        PostgreSql = 1
    }

    public class Archive : IDbContext
    {
        #region Private Properties

        private string ConnectionString { get; set; }
        private IDbContext Context { get; set; }
        private Providers Provider { get; set; } = Providers.PostgreSql;

        #endregion Private Properties


        #region Public Methods

        public TimeSeries GetTimeSeries(string name)
        {
            return Context.GetTimeSeries(name);
        }

        public void SetParams<TContext>(Providers provider, string connectionString) where TContext : DbContext
        {
            Provider = provider;
            ConnectionString = connectionString;

            DbContextOptionsBuilder<TContext> optionsBuilder = new DbContextOptionsBuilder<TContext>();

            switch (Provider)
            {
                case Providers.PostgreSql:
                    optionsBuilder.UseNpgsql(ConnectionString);
                    break;

                default:
                    throw new Exception("Не задан провайдер подключения к БД");
            }

            Context = (IDbContext) Activator.CreateInstance(typeof(TContext), new object[] {optionsBuilder.Options});
        }

        #endregion Public Methods
    }
}