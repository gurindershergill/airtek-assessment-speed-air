using SpeedyAir.Interfaces;
using SpeedyAir.Models;

namespace SpeedyAir.Controllers
{
    public class OrderManager : IOrder
    {
        public void ProcessOrders(List<Order> orders, Dictionary<string, List<Flight>> flightsDictionary)
        {
            foreach (Order order in orders)
            {
                List<Flight> matchingFlights = new List<Flight>();
                if (flightsDictionary.ContainsKey(order.Destination))
                {
                    matchingFlights = flightsDictionary[order.Destination];
                }
                matchingFlights = matchingFlights.Where(f => f.FlightUsedCapacity < f.FlightCapacity).ToList();

                if (matchingFlights == null || matchingFlights.Count == 0)
                {
                    Console.WriteLine($"Order: {order.OrderId}, flightNumber: not scheduled");
                }
                else
                {
                    Console.WriteLine($"Order: {order.OrderId}, flightNumber: {matchingFlights[0].FlightId}, departure: {matchingFlights[0].Departure}, arrival: {matchingFlights[0].Arrival}, day: {matchingFlights[0].FlightDay}");
                    matchingFlights[0].FlightUsedCapacity++;
                }
               
            }
        }
    }
}
