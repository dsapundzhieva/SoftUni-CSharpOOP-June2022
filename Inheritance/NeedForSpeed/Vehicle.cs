using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;
        public Vehicle(int horsePower, double fuel)
        {
            this.Fuel = fuel;
            this.HorsePower = horsePower;
            this.FuelConsumption = DefaultFuelConsumption;
        }

        public virtual double FuelConsumption { get; set; }

        public double Fuel { get; set; }

        public int HorsePower { get; set; }

        public virtual void Drive(double kilometers)
        {
            double neededFuel = (kilometers * FuelConsumption);

            if (this.Fuel >= neededFuel)
            {
                this.Fuel -= neededFuel;
            }
        }
    }
}
