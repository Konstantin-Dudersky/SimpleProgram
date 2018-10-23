using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SimpleProgram.Lib.Archives.MasterScada
{
    public class MasterScadaDb : DbContext, IDbContext
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

        public TimeSeries GetTimeSeries(string name)
        {
            TimeSeries values = new TimeSeries();

            var itemid = (from i in masterscadadataitems
                where i.name == name
                select i.itemid).FirstOrDefault();

            IQueryable<TimeValue> data = (from v in masterscadadataraw
                where v.itemid == itemid && v.quality == 192 && v.layer == 1
                orderby v.Time
                select new TimeValue(DateTime.FromBinary(v.Time), (double) v.value));

            values.AddRange(data);

            return values;
        }
    }
}