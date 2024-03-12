using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyAir.Models
{
    public class Flight
    {
        public int FlightId { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public int FlightDay { get; set; }
        public string FlightDepartureTime { get; set;}
        public string FlightArrivalTime { get; set;}
        public int FlightCapacity { get; } = 20;

        public int FlightUsedCapacity { get; set; }
    }
}
