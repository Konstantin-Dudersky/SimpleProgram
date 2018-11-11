using System;
using System.Linq;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Microsoft.EntityFrameworkCore;

namespace SimpleProgram.Lib.Archives.MasterScada
{
    public class MasterScadaDb : DbContext, ITagArchive
    {
        public MasterScadaDb()
        {
        }

        public MasterScadaDb(DbContextOptions<MasterScadaDb> options)
            : base(options)
        {
        }

        public virtual DbSet<masterscadadataitems> masterscadadataitems { get; set; }
        public virtual DbSet<masterscadadataraw> masterscadadataraw { get; set; }
        public virtual DbSet<masterscadaprojects> masterscadaprojects { get; set; }
        public virtual DbSet<masterscadaproperties> masterscadaproperties { get; set; }

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

        #endregion
    }
}