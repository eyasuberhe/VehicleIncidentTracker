using System;

namespace VehicleIncidentTracker.Core.Entities
{
    public class Incident : BaseEntity
    {
        public string Note { get; set; }
        public DateTime IncidentDate { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        public Incident() { }

        public Incident(string note, DateTime incidentDate, int vehicleId)
        {
            Note = note;
            IncidentDate = incidentDate;
            VehicleId = vehicleId;
        }
    }
}
