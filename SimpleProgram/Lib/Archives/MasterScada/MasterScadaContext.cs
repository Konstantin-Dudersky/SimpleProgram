using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

// ReSharper disable IdentifierTypo
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace SimpleProgram.Lib.Archives.MasterScada
{
    public class MasterScadaDb : DbContext, IDatabaseInterop
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

        private async Task<int> GetItemid(string name)
        {
            return await
                (from i in masterscadadataitems
                where i.name == name
                select i.itemid).FirstOrDefaultAsync();
        }
        
        private async Task<IEnumerable<masterscadadataraw>> GetMasterscadadataraws(string name, DateTime begin, DateTime end,
            double lessThen, double moreThen)
        {
            var fromDtBinary = begin.ToBinary();
            var toDtBinary = end.ToBinary();

            var itemid = await GetItemid(name);
            
            var data = from v in masterscadadataraw
                where v.itemid == itemid && v.quality == 192 && v.layer == 1 &&
                      v.Time >= fromDtBinary && v.Time <= toDtBinary &&
                      v.value < lessThen && v.value > moreThen
                orderby v.Time
                select v;

            return await data.ToArrayAsync();
        }

        #region IArchiveInterop

        public async Task<object[]> GetEntitiesAsync(string name, DateTime begin, DateTime end, double lessThen, double moreThen)
        {
            var rows = await GetMasterscadadataraws(name, begin, end, lessThen, moreThen);
            return rows.Select(x => (object) x).ToArray();
        }

        public async Task<TimeSeries> GetTimeSeriesAsync(string name, DateTime dateTimeFrom, DateTime dateTimeTo,
            double lessThen, double moreThen)
        {
            var ts = new TimeSeries();

            var entities = await GetMasterscadadataraws(name, dateTimeFrom, dateTimeTo, lessThen, moreThen);

            var data = from e in entities
                select new {Time = DateTime.FromBinary(e.Time).ToLocalTime(), Value = e.value};

            foreach (var timeValue in data) ts.Add(timeValue.Time, timeValue.Value);

            return ts;
        }

        public async Task<double> GetArchiveValueAsync(string name, DateTime begin, DateTime end,
            SimplifyType simplifyType = SimplifyType.None)
        {
            var fromDtBinary = begin.ToBinary();
            var toDtBinary = end.ToBinary();
            
            var itemid = await GetItemid(name);

            masterscadadataraw last;

            masterscadadataraw first;
            switch (simplifyType)
            {
                case SimplifyType.None:
                    break;
                
                case SimplifyType.Increment:
                    first = await (from r in masterscadadataraw
                        where r.itemid == itemid && r.quality == 192 && r.layer == 1 && r.Time >= fromDtBinary
                        orderby r.Time
                        select r).FirstOrDefaultAsync();
            
                    last = await (from r in masterscadadataraw
                        where r.itemid == itemid && r.quality == 192 && r.layer == 1 && r.Time <= toDtBinary
                        orderby r.Time
                        select r).LastOrDefaultAsync();

                    if (first?.value == null || last?.value == null)
                        return 0;
            
                    return (double) last.value - (double) first.value;
                
                case SimplifyType.Average:
                    break;
                
                case SimplifyType.Max:
                    break;
                
                case SimplifyType.Min:
                    break;
                
                case SimplifyType.Last:
                    last = await (from r in masterscadadataraw
                        where r.itemid == itemid && r.quality == 192 && r.layer == 1 && r.Time <= toDtBinary
                        orderby r.Time
                        select r).LastOrDefaultAsync();
                    
                    if (last?.value == null)
                        return 0;

                    return (double) last.value;
                
                case SimplifyType.First:
                    first = await (from r in masterscadadataraw
                        where r.itemid == itemid && r.quality == 192 && r.layer == 1 && r.Time >= fromDtBinary
                        orderby r.Time
                        select r).FirstOrDefaultAsync();
                    
                    if (first?.value == null)
                        return 0;
                    
                    return (double) first.value;
                
                default:
                    throw new ArgumentOutOfRangeException(nameof(simplifyType), simplifyType, null);
            }
            
            throw new NotImplementedException($"{nameof(GetArchiveValueAsync)} - {simplifyType}");

        }

        #endregion
    }
}