using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleIncidentTracker.Core.Entities;

namespace VehicleIncidentTracker.Web.EndPoints.VehicleEndPoints
{
    public class VehicleResponse: BaseMessage
    {
        public string VIN { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public IEnumerable<Incident> Incidents { get; set; }
    }
}
