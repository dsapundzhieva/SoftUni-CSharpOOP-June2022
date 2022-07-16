namespace Vehicles.Core
{
    using System;
    using Models;
    using Vehicles.Exceptions;

    public class Engine : IEngine
    {
        private readonly Vehicle car;
        private readonly Vehicle truck;
        private readonly Vehicle bus;


        public Engine(Vehicle car, Vehicle truck, Vehicle bus)
        {
            this.car = car;
            this.truck = truck;
            this.bus = bus;
        }

        public void Start()
        {
            int numberOfCmds = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCmds; i++)
            {
                try
                {
                    string[] cmdArgs = Console.ReadLine()
                       .Split();

                    string cmdType = cmdArgs[0];
                    string vehicleType = cmdArgs[1];

                    if (cmdType == "Drive")
                    {
                        double distance = double.Parse(cmdArgs[2]);

                        if (vehicleType == "Car")
                        {
                            Console.WriteLine(car.Drive(distance));
                        }
                        else if (vehicleType == "Truck")
                        {
                            Console.WriteLine(truck.Drive(distance));
                        }
                        else if (vehicleType == "Bus")
                        {
                            Console.WriteLine(bus.Drive(distance));
                        }

                    }
                    else if (cmdType == "Refuel")
                    {
                        double refuel = double.Parse(cmdArgs[2]);

                        if (vehicleType == "Car")
                        {
                            car.Refuel(refuel);
                        }
                        else if (vehicleType == "Truck")
                        {
                            truck.Refuel(refuel);
                        }
                        else if (vehicleType == "Bus")
                        {
                            bus.Refuel(refuel);
                        }
                    }
                    else if (cmdType == "DriveEmpty")
                    {
                        double distance = double.Parse(cmdArgs[2]);

                        Console.WriteLine(bus.DriveEmpty(distance));
                    }
                }
                catch (InvalidFuelException ife)
                {
                    Console.WriteLine(ife.Message);
                }
                catch (InvalidVehicleType ivt)
                {
                    Console.WriteLine(ivt.Message);
                }
                catch (NegativeFuelException nfe)
                {
                    Console.WriteLine(nfe.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }

            Console.WriteLine(this.car);
            Console.WriteLine(this.truck);
            Console.WriteLine(this.bus);

        }
    }
}
