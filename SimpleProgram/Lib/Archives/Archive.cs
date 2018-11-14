using System;
using Microsoft.EntityFrameworkCore;
using SimpleProgram.Lib.Archives.MasterScada;

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

        #region ITagArchive

        public TimeSeries GetTimeSeries(string name, DateTime dateTimeFrom, DateTime dateTimeTo)
        {
            TimeSeries data;

            using (var context = (DbContext) Activator.CreateInstance(type, _optionsBuilder.Options))
            {
                data =  ((IArchiveInterop) context).GetTimeSeries(name, dateTimeFrom, dateTimeTo);
            }
            
            return data;
        }

        public void DeleteArchiveData(string name, DateTime begin, DateTime end)
        {
            using (var context = (DbContext) Activator.CreateInstance(type, _optionsBuilder.Options))
            {
                var entities = ((IArchiveInterop) context).GetEntities(name, begin, end);
                context.RemoveRange(entities);
                context.SaveChanges();
            }
        }

        #endregion
    }

    interface IArchiveInterop
    {
        TimeSeries GetTimeSeries(string name, DateTime dateTimeFrom, DateTime dateTimeTo);
        object[] GetEntities(string name, DateTime begin, DateTime end);
    }
}