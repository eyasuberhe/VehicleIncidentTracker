using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleIncidentTracker.Core.Entities;
using VehicleIncidentTracker.Core.Interfaces;
using VehicleIncidentTracker.Web.EndPoints.IncidentEndPoints;

namespace VehicleIncidentTracker.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IVehicleService _vehicleService;

        public IncidentController(IRepository repository, IVehicleService vehicleService)
        {
            _repository = repository;
            _vehicleService = vehicleService;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var incidents = (await _repository.ListAsync<Incident>("Vehicle"))

                .Select(incident => new IncidentResponse
                {
                    Id = incident.Id,
                    Note = incident.Note,
                    IncidentDate = incident.IncidentDate.ToString("yyyy-MM-dd"),
                    VehicleId = incident.VehicleId,
                    VIN = incident.Vehicle.VIN,
                    Make = incident.Vehicle.Make,
                    Year = incident.Vehicle.Year
                });

            return Ok(incidents);
        }

        [HttpPost]
        public async Task<ActionResult<IncidentResponse>> Create(NewIncidentRequest request)
        {
            var vehicle = _repository.ListAsync<Vehicle>().Result.FirstOrDefault(v => v.VIN == request.VIN);

            if (vehicle is null)
            {
                vehicle = await _vehicleService.DecodeVin(request.VIN);
                vehicle = await _repository.AddAsync(vehicle);
            }

            var incident = new Incident(request.Note, request.IncidentDate, vehicle.Id);

            var newIncident = await _repository.AddAsync(incident);

            var response = new IncidentResponse
            {
                Id = newIncident.Id,
                Note = newIncident.Note,
                IncidentDate = newIncident.IncidentDate.ToString("yyyy-MM-dd"),
                VehicleId = newIncident.VehicleId,
                VIN = vehicle.VIN,
                Make = vehicle.Make,
                Year = vehicle.Year
            };

            return Ok(response);
        }
    }
}
