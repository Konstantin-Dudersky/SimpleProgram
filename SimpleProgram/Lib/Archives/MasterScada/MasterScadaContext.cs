using System;
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

        #region ITagArchive

        public TimeSeries GetTimeSeries(string name, DateTime dateTimeFrom, DateTime dateTimeTo)
        {
            var ts = new TimeSeries();

            var fromDtBinary = dateTimeFrom.ToBinary();
            var toDtBinary = dateTimeTo.ToBinary();

            var itemid = (from i in masterscadadataitems
                where i.name == name
                select i.itemid).FirstOrDefault();

            var data = from v in masterscadadataraw
                where v.itemid == itemid && v.quality == 192 && v.layer == 1 &&
                      v.Time >= fromDtBinary && v.Time <= toDtBinary
                orderby v.Time
                select new {Time = DateTime.FromBinary(v.Time), Value = (double) v.value};

            foreach (var timeValue in data) ts.Add(timeValue.Time, timeValue.Value);

            return ts;
        }

        public void DeleteArchiveData(string name, DateTime begin, DateTime end)
        {
            
        }

        public object[] GetEntities(string name, DateTime begin, DateTime end)
        {
            var fromDtBinary = begin.ToBinary();
            var toDtBinary = end.ToBinary();
            
            var itemid = (from i in masterscadadataitems
                where i.name == name
                select i.itemid).FirstOrDefault();

            var data = from v in masterscadadataraw
                where v.itemid == itemid && v.quality == 192 && v.layer == 1 &&
                      v.Time >= fromDtBinary && v.Time <= toDtBinary
                orderby v.Time
                select v;

            return data.ToArray();
        }

        public string ArchiveName { get; set; }
        
        

        #endregion
    }
}