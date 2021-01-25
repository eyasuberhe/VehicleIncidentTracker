using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleIncidentTracker.Core.Entities;

namespace VehicleIncidentTracker.Core.Interfaces
{
    public interface IVehicleService
    {
        Task<Vehicle> DecodeVin(string vin);
    }
}
