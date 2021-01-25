using System;
using System.Collections.Generic;

namespace VehicleIncidentTracker.Core.Entities
{
    public class Vehicle : BaseEntity
    {
        public string VIN { get; private set; }
        public string Make { get; private set; }
        public string Model { get; private set; }
        public string Year { get; private set; }

        private List<Incident> _incidents;

        public IEnumerable<Incident> Incidents => _incidents.AsReadOnly();

        protected Vehicle()
        {

            _incidents = new List<Incident>();
        }

        public Vehicle(string vin, string make, string model, string year)
        {
            VIN = vin;
            Make = make;
            Model = model;
            Year = year;
        }
    }
}
