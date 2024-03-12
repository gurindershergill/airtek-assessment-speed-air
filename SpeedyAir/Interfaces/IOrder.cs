using SpeedyAir.Models;

namespace SpeedyAir.Interfaces
{
    public interface IOrder
    {
        public void ProcessOrders(List<Order> orders, Dictionary<string, List<Flight>> flightsDictionary);
    }

}
