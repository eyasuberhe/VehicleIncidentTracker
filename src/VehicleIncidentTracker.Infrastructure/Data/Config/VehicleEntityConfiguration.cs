using VehicleIncidentTracker.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VehicleIncidentTracker.Infrastructure.Data.Config
{
    public class VehicleEntityConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(v => v.Id);

            builder.Property(v => v.Id)
               .UseHiLo("vehicleseq")
               .IsRequired();

            builder.Property(v => v.VIN)
                .IsRequired();
            builder.Property(v => v.Make)
                .IsRequired();
            builder.Property(v => v.Model)
                .IsRequired();
            builder.Property(v => v.Year)
                .IsRequired();
            builder.HasMany(b => b.Incidents)
               .WithOne()
               .HasForeignKey("VehicleId")
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
