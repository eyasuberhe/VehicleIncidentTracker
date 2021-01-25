using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleIncidentTracker.Core.Entities;
using VehicleIncidentTracker.Core.Interfaces;
using VehicleIncidentTracker.Web.Controllers;
using VehicleIncidentTracker.Web.EndPoints.IncidentEndPoints;
using Xunit;

namespace VehicleIncidentTracker.UnitTests.Controllers
{
    public class IncidentControllerTest
    {
        private readonly Mock<IRepository> _repositoryMock;
        private readonly Mock<IVehicleService> _vehicleServiceMock;

        public IncidentControllerTest()
        {
            _repositoryMock = new Mock<IRepository>();
            _vehicleServiceMock = new Mock<IVehicleService>();
        }

        [Fact]
        public async Task Get_incidents_success()
        {
            _repositoryMock.Setup(repo => repo.ListAsync<Incident>("Vehicle"))
                .ReturnsAsync(GetFakeIncidents());

            var controller = new IncidentController(_repositoryMock.Object, _vehicleServiceMock.Object);

            var response = await controller.Get();
            OkObjectResult actioResult = response as OkObjectResult;

            Assert.NotNull(actioResult);

            var incidents = actioResult.Value as IEnumerable<IncidentResponse>;
            Assert.Single(incidents);
            Assert.Equal("Hit a post", incidents.FirstOrDefault().Note);
        }

        private List<Incident> GetFakeIncidents()
        {
            return new List<Incident>()
            {
                new Incident
                {
                    Note = "Hit a post",
                    IncidentDate =  DateTime.UtcNow,
                    VehicleId = 1,
                    Vehicle = new Vehicle("1VXBR12EXCP901214", "TOYOTA", "COROLLA CE", "2005")
                 }
            };
        }
    }
}
