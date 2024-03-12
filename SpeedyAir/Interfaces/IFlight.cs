using SpeedyAir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyAir.Interfaces
{
    public interface IFlight
    {
        public void SetFlightsData(List<Flight> flights);
        public void ShowFlights();

    }
}
