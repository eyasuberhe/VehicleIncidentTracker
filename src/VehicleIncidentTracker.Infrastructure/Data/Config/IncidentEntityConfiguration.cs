using VehicleIncidentTracker.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VehicleIncidentTracker.Infrastructure.Data.Config
{
    public class IncidentEntityConfiguration : IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id)
               .UseHiLo("incidentseq")
               .IsRequired();

            builder.Property(i => i.Note)
                .IsRequired();
            builder.Property(i => i.IncidentDate)
                .IsRequired();
            builder.HasOne(i => i.Vehicle)
                .WithMany()
                .HasForeignKey(i => i.VehicleId);
        }
    }
}
