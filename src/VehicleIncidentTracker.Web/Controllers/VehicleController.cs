using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VehicleIncidentTracker.Core.Entities;
using VehicleIncidentTracker.Core.Interfaces;
using VehicleIncidentTracker.Web.EndPoints.VehicleEndPoints;

namespace VehicleIncidentTracker.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IRepository _repository;

        public VehicleController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<VehicleResponse>>> Get()
        {
            var response = (await _repository.ListAsync<Vehicle>())
                .Select(vehicle => new VehicleResponse
                {
                    VIN = vehicle.VIN,
                    Make = vehicle.Make,
                    Model = vehicle.Model,
                    Year = vehicle.Year,
                    Incidents = vehicle.Incidents
                });

            return Ok(response);
        }
    }
}
