using VehicleIncidentTracker.Core.Entities;
using VehicleIncidentTracker.UnitTests;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace VehicleIncidentTracker.IntegrationTests.Data
{
    public class EfRepositoryAdd : BaseEfRepoTestFixture
    {
        [Fact]
        public async Task AddsItemAndSetsId()
        {
            var repository = GetRepository();
            var item = new Vehicle("1VXBR12EXCP901214", "TOYOTA", "COROLLA CE", "2005");

            await repository.AddAsync(item);

            var newItem = (await repository.ListAsync<Vehicle>("Incidents"))
                            .FirstOrDefault();

            Assert.Equal(item, newItem);
            Assert.True(newItem?.Id > 0);
        }
    }
}
