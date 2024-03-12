using SpeedyAir.Controllers;
using SpeedyAir.Interfaces;

class Program
{
    static void Main(string[] args)
    {
        IFlight flightOperations = new FlightManager();
        IOrder orderOperations = new OrderManager();
        var inventoryManagement = new OrderFlightManagement(flightOperations, orderOperations);
        inventoryManagement.Execute();
    }
}