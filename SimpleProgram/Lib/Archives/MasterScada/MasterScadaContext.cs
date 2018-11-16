using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

// ReSharper disable IdentifierTypo
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace SimpleProgram.Lib.Archives.MasterScada
{
    public class MasterScadaDb : DbContext, IArchiveInterop
    {
        public MasterScadaDb(DbContextOptions options)
            : base(options)
        {
        }

        protected virtual DbSet<masterscadadataitems> masterscadadataitems { get; set; }
        protected virtual DbSet<masterscadadataraw> masterscadadataraw { get; set; }
        protected virtual DbSet<masterscadaprojects> masterscadaprojects { get; set; }
        protected virtual DbSet<masterscadaproperties> masterscadaproperties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<masterscadadataitems>(entity => { entity.HasKey(e => new {e.projectid, e.itemid}); });

            modelBuilder.Entity<masterscadadataraw>(entity =>
            {
                entity.HasKey(e => new {e.projectid, e.layer, e.itemid, e.Time});

                entity.HasIndex(e => new {e.projectid, e.layer, e.itemid, e.Time})
                    .HasName("masterscadadatarawindex");
            });

            modelBuilder.Entity<masterscadaprojects>(entity =>
            {
                entity.Property(e => e.projectid)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<masterscadaproperties>(entity =>
            {
                entity.Property(e => e.propertyid)
                    .ValueGeneratedNever();
            });
        }

        private int GetItemid(string name)
        {
            return 
                (from i in masterscadadataitems
                where i.name == name
                select i.itemid).FirstOrDefault();
        }
        
        private IEnumerable<masterscadadataraw> GetMasterscadadataraws(string name, DateTime begin, DateTime end,
            double lessThen, double moreThen)
        {
            var fromDtBinary = begin.ToBinary();
            var toDtBinary = end.ToBinary();

            /*var itemid = (from i in masterscadadataitems
                where i.name == name
                select i.itemid).FirstOrDefault();*/

            var itemid = GetItemid(name);
            
            var data = from v in masterscadadataraw
                where v.itemid == itemid && v.quality == 192 && v.layer == 1 &&
                      v.Time >= fromDtBinary && v.Time <= toDtBinary &&
                      v.value < lessThen && v.value > moreThen
                orderby v.Time
                select v;

            return data.ToArray();
        }

        #region ITagArchive

        public object[] GetEntities(string name, DateTime begin, DateTime end, double lessThen, double moreThen)
        {
            return GetMasterscadadataraws(name, begin, end, lessThen, moreThen).Select(x => (object) x).ToArray();
        }

        public TimeSeries GetTimeSeries(string name, DateTime dateTimeFrom, DateTime dateTimeTo,
            double lessThen, double moreThen)
        {
            var ts = new TimeSeries();

            var entities = GetMasterscadadataraws(name, dateTimeFrom, dateTimeTo, lessThen, moreThen);

            var data = from e in entities
                select new {Time = DateTime.FromBinary(e.Time).ToLocalTime(), Value = e.value};

            foreach (var timeValue in data) ts.Add(timeValue.Time, timeValue.Value);

            return ts;
        }

        public double Increment(string name, DateTime begin, DateTime end)
        {
            var fromDtBinary = begin.ToBinary();
            var toDtBinary = end.ToBinary();
            
            var itemid = GetItemid(name);

            var first = (from r in masterscadadataraw
                where r.itemid == itemid && r.quality == 192 && r.layer == 1 && r.Time >= fromDtBinary
                orderby r.Time
                select r).FirstOrDefault();
            
            var last = (from r in masterscadadataraw
                where r.itemid == itemid && r.quality == 192 && r.layer == 1 && r.Time <= toDtBinary
                orderby r.Time
                select r).LastOrDefault();

            if (first?.value == null || last?.value == null)
                return 0;
            
            return (double) last.value - (double) first.value;
        }

        #endregion
    }
}