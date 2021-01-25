using VehicleIncidentTracker.Core.Entities;
using VehicleIncidentTracker.UnitTests;
using System;
using System.Threading.Tasks;
using Xunit;

namespace VehicleIncidentTracker.IntegrationTests.Data
{
    public class EfRepositoryDelete : BaseEfRepoTestFixture
    {
        [Fact]
        public async Task DeletesItemAfterAddingIt()
        {
            // add an item
            var repository = GetRepository();
            var vin = Guid.NewGuid().ToString();
            var item = new Vehicle("1VXBR12EXCP901214", "TOYOTA", "COROLLA CE", "2005");
            await repository.AddAsync(item);

            // delete the item
            await repository.DeleteAsync(item);

            // verify it's no longer there
            Assert.DoesNotContain(await repository.ListAsync<Vehicle>("Incidents"),
                i => i.VIN == vin);
        }
    }
}
