using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleIncidentTracker.Web.EndPoints.IncidentEndPoints
{
    public class NewIncidentRequest: BaseMessage
    {
        [Required]
        public string VIN { get; set; }
        [Required]
        public string Note { get; set; }
        [Required]
        public DateTime IncidentDate { get; set; }
    }
}
