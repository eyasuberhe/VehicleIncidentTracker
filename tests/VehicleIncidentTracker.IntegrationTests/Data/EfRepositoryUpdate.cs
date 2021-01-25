using VehicleIncidentTracker.Core.Entities;
using VehicleIncidentTracker.UnitTests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace VehicleIncidentTracker.IntegrationTests.Data
{
    public class EfRepositoryUpdate : BaseEfRepoTestFixture
    {
        [Fact]
        public async Task UpdatesItemAfterAddingIt()
        {            
           var repository = GetRepository();
            var vin = Guid.NewGuid().ToString();
            var incident = new Incident("Incident Note", DateTime.UtcNow, 1);

            await repository.AddAsync(incident);

            // detach the item so we get a different instance
            _dbContext.Entry(incident).State = EntityState.Detached;

            // fetch the item and update its title
            var newIncident = (await repository.ListAsync<Incident>(""))
                .FirstOrDefault(i => i.Note == "Incident Note");
            Assert.NotNull(newIncident);
            Assert.NotSame(incident, newIncident);
            var newNote = "Another Incident Note";
            newIncident.Note  = newNote;

            // Update the item
            await repository.UpdateAsync(newIncident);
            var updatedItem = (await repository.ListAsync<Incident>(""))
                .FirstOrDefault(i => i.Note == newNote);

            Assert.NotNull(updatedItem);
            Assert.NotEqual(incident.Note, updatedItem.Note);
            Assert.Equal(newIncident.Id, updatedItem.Id);
        }
    }
}
