using SpeedyAir.Interfaces;
using SpeedyAir.Models;

namespace SpeedyAir.Controllers
{
    public class FlightManager : IFlight
    {
        private List<Flight> flightsData;

        public FlightManager()
        {
            flightsData = new List<Flight>();
        }

        public void SetFlightsData(List<Flight> flights)
        {
            flightsData = flights;
        }

        public void ShowFlights()
        {
            foreach (Flight flight in flightsData)
            {
                Console.WriteLine($"Flight: {flight.FlightId}, Departure: {flight.Departure}, Arrival: {flight.Arrival}, Day: {flight.FlightDay}, Departure Time: {flight.FlightDepartureTime}, Arrival Time: {flight.FlightArrivalTime}  ");
            }
        }
    }
}
