using SpeedyAir.Models;
using SpeedyAir.Interfaces;
using Newtonsoft.Json;

namespace SpeedyAir.Controllers
{
    public class OrderFlightManagement
    {
        private readonly IFlight flightOperations;
        private readonly IOrder orderOperations;

        public OrderFlightManagement(IFlight flightOperations, IOrder orderOperations)
        {
            this.flightOperations = flightOperations;
            this.orderOperations = orderOperations;
        }

        public void Execute()
        {
            List<Flight> flights = new List<Flight>
            {
                new Flight { FlightId = 1, Departure = "YUL", Arrival = "YYZ", FlightDay = 1, FlightDepartureTime = "12 PM", FlightArrivalTime="12 AM"},
                new Flight { FlightId = 2, Departure = "YUL", Arrival = "YYC", FlightDay = 1, FlightDepartureTime = "12 PM", FlightArrivalTime="12 AM"},
                new Flight { FlightId = 3, Departure = "YUL", Arrival = "YVR", FlightDay = 1, FlightDepartureTime = "12 PM", FlightArrivalTime="12 AM"},
                new Flight { FlightId = 4, Departure = "YUL", Arrival = "YYZ", FlightDay = 2, FlightDepartureTime = "12 PM", FlightArrivalTime="12 AM"},
                new Flight { FlightId = 5, Departure = "YUL", Arrival = "YYC", FlightDay = 2, FlightDepartureTime = "12 PM", FlightArrivalTime="12 AM"},
                new Flight { FlightId = 6, Departure = "YUL", Arrival = "YVR", FlightDay = 2, FlightDepartureTime = "12 PM", FlightArrivalTime="12 AM"}
            };

            Dictionary<string, Order> ordersData;
            List<Order> orders = new List<Order>();
            using (StreamReader r = new StreamReader("..\\..\\..\\orders.json"))
            {
                
                string json = r.ReadToEnd();
                ordersData = JsonConvert.DeserializeObject<Dictionary<string, Order>>(json);
                foreach (var orderItem in ordersData)
                {
                    Order order = new Order();
                    order.OrderId = orderItem.Key.Replace("order-","");
                    order.Destination = orderItem.Value.Destination;
                    orders.Add(order);
                }
            }

            Dictionary<string, List<Flight>> flightsDictionary = flights
                .GroupBy(f => f.Arrival)
                .ToDictionary(g => g.Key, g => g.ToList());

            flightOperations.SetFlightsData(flights);
            Console.WriteLine("Flight Schedule:");
            flightOperations.ShowFlights();
            Console.WriteLine("\nFlight Itineraries:");
            orderOperations.ProcessOrders(orders, flightsDictionary);
        }
    }
}
