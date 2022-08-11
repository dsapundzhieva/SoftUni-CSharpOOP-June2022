namespace CarRacing.Models.Cars
{
    public class SuperCar : Car
    {
        private const double DefaultFuelAvailable = 80;
        private const double DefaultFuelConsumptionPerRace = 10;

        public SuperCar(string make, string model, string vIN, int horsePower) 
            : base(make, model, vIN, horsePower, DefaultFuelAvailable, DefaultFuelConsumptionPerRace)
        {
        }

    }
}
