using VehicleIncidentTracker.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VehicleIncidentTracker.Core.Entities;
using VehicleIncidentTracker.Core;
using System.Reflection;
using JetBrains.Annotations;
using VehicleIncidentTracker.Infrastructure.Data.Config;

namespace VehicleIncidentTracker.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Incident> Incidents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new VehicleEntityConfiguration());
            modelBuilder.ApplyConfiguration(new IncidentEntityConfiguration());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}