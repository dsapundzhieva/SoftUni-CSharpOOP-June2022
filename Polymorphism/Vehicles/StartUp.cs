
namespace Vehicles
{
    using System;

    using Core;

    using Factories;

    using Models;

    public class StartUp
    {
        static void Main()
        {
            string[] carInfo = Console.ReadLine()
               .Split();
            string[] truckInfo = Console.ReadLine()
                .Split();
            string[] busInfo = Console.ReadLine()
                .Split();

            VehicleFactory vehicleFactory = new VehicleFactory();

            Vehicle car = vehicleFactory
                .CreateVehicle(carInfo[0], double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));

            Vehicle truck = vehicleFactory.
                CreateVehicle(truckInfo[0], double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));

            Vehicle bus = vehicleFactory.
                CreateVehicle(busInfo[0], double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

            IEngine engine = new Engine(car, truck, bus);

            engine.Start();
        }
    }
}
