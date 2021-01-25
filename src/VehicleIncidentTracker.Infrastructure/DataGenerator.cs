using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleIncidentTracker.Core.Entities;
using VehicleIncidentTracker.Infrastructure.Data;

namespace VehicleIncidentTracker.Infrastructure
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                // Look for any board games.
                if (context.Vehicles.Any())
                {
                    return;   // Data was already seeded
                }

                context.Vehicles.AddRange(
                    new Vehicle("1VXBR12EXCP901214", "TOYOTA", "COROLLA CE", "2005"),
                    new Vehicle("JM1BJ227530678095", "NISSAN", "ALTIMA", "2006"),
                    new Vehicle("2HKRM3H79EH556557", "JEEP", "Wrangler", "2005"));

                if(context.Incidents.Any())
                {
                    return;
                }

                context.SaveChanges();

                context.Incidents.AddRange(
                    new Incident("Incident Note 1", DateTime.UtcNow, 1),
                    new Incident("Incident Note 2", DateTime.UtcNow, 1),
                    new Incident("Incident Note 3", DateTime.UtcNow, 2)
                );

                context.SaveChanges();
            }
        }
    }
}
