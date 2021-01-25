using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleIncidentTracker.Web.EndPoints.IncidentEndPoints
{
    public class IncidentResponse: BaseMessage
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public string IncidentDate { get; set; }
        public int VehicleId { get; set; }
        public string VIN { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
    }
}
