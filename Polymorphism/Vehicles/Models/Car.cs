namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double CarFuelConsumptionIncrease = 0.9;
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        protected override double FuelConsumprionModifier
            => CarFuelConsumptionIncrease;
    }
}
