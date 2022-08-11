namespace CarRacing.Models.Cars
{
    using System;
    public class TunedCar : Car
    {
        private const double DefaultFuelAvailable = 65;
        private const double DefaultFuelConsumptionPerRace = 7.5;
        private const double DefaultHorsePowerReducer = 0.03;

        public TunedCar(string make, string model, string vIN, int horsePower)
            : base(make, model, vIN, horsePower, DefaultFuelAvailable, DefaultFuelConsumptionPerRace)
        {
        }

        public override void Drive()
        {
            base.Drive();
            int roundedHorsePower = (int)(Math.Round(DefaultHorsePowerReducer * this.HorsePower, 0));
            this.HorsePower -= roundedHorsePower;
        }
    }
}
