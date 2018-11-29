using System;
using Microsoft.EntityFrameworkCore;

namespace SimpleProgram.Lib.Archives
{
    public enum Providers
    {
        PostgreSql = 1
    }

    public class Database<T> : IDatabase
        where T : DbContext
    {
        private readonly DbContextOptionsBuilder<T> _optionsBuilder;

        private readonly Type _type;


        public Database(Providers provider, string connectionString)
        {
            ConnectionString = connectionString;
            Provider = provider;

            _optionsBuilder = new DbContextOptionsBuilder<T>();

            switch (provider)
            {
                case Providers.PostgreSql:
                    _optionsBuilder.UseNpgsql(connectionString);
                    break;

                default:
                    throw new Exception("Не задан провайдер подключения к БД");
            }

            _type = typeof(T);
        }

        public string ArchiveName { get; set; } = "Archive";

        public string ConnectionString { get; }
        public Providers Provider { get; }


        public DbContext GetDbContext()
        {
            return (DbContext) Activator.CreateInstance(_type, _optionsBuilder.Options);
        }
    }
}