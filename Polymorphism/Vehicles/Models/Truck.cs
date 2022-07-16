
namespace Vehicles.Models
{
    using System;
    using Vehicles.Exceptions;
    public class Truck : Vehicle
    {
        private const double TruckFuelConsumptionIncrease = 1.6;
        private const double RefuelCoeffiecient = 0.95;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
             : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        protected override double FuelConsumprionModifier
            => TruckFuelConsumptionIncrease;

        public override void Refuel(double fuelQuantity)
        {
            if (fuelQuantity + this.FuelQuantity > this.TankCapacity)
            {
                throw new InvalidFuelException(
                    String.Format(ExeptionMessages.InvalidFuelAmount, fuelQuantity));
            }
            base.Refuel(fuelQuantity * RefuelCoeffiecient);
        }
    }
}
