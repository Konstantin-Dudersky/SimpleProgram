using System;
using Microsoft.EntityFrameworkCore;
using SimpleProgram.Lib.Archives.MasterScada;

namespace SimpleProgram.Lib.Archives
{
    public enum Providers
    {
        // ReSharper disable once IdentifierTypo
        PostgreSql = 1
    }

    public class Archive<TCont> : ITagArchive
        where TCont: DbContext
    {
        public string ArchiveName { get; set; } = "Archive";

        private string ConnectionString { get; set; }
        private ITagArchive Context { get; set; }
        private Providers Provider { get; set; } = Providers.PostgreSql;

        private readonly Type type;
        private readonly DbContextOptionsBuilder<TCont> _optionsBuilder;
        

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

        public TimeSeries GetTimeSeries(string name, DateTime dateTimeFrom, DateTime dateTimeTo,
            double lessThen, double moreThen)
        {
            TimeSeries data;

            using (var context = (DbContext) Activator.CreateInstance(type, _optionsBuilder.Options))
            {
                data =  ((IArchiveInterop) context).GetTimeSeries(name, dateTimeFrom, dateTimeTo, lessThen, moreThen);
            }
            
            return data;
        }

        public void DeleteArchiveData(string name, DateTime begin, DateTime end, double lessThen, double moreThen)
        {
            using (var context = (DbContext) Activator.CreateInstance(type, _optionsBuilder.Options))
            {
                var entities = ((IArchiveInterop) context).GetEntities(name, begin, end, lessThen, moreThen);
                context.RemoveRange(entities);
                context.SaveChanges();
            }
        }
        
        public double Increment(string name, DateTime begin, DateTime end)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    internal interface IArchiveInterop
    {
        TimeSeries GetTimeSeries(string name, DateTime dateTimeFrom, DateTime dateTimeTo,
            double lessThen, double moreThen);
        object[] GetEntities(string name, DateTime begin, DateTime end, double lessThen, double moreThen);
    }
}