namespace CarRacing.Models.Cars
{
    using System;
    using CarRacing.Models.Cars.Contracts;
    public abstract class Car : ICar
    {
        private const int DefaultVinLenght = 17;
        private string make;
        private string model;
        private string vin;
        private int horsePower;
        private double fuelAvailable;
        private double fuelConsumtpionPerRace;

        protected Car(string make, string model, string vIN, int horsePower, double fuelAvailable, double fuelConsumptionPerRace)
        {
            this.Make = make;
            this.Model = model;
            this.VIN = vIN;
            this.HorsePower = horsePower;
            this.FuelAvailable = fuelAvailable;
            this.FuelConsumptionPerRace = fuelConsumptionPerRace;
        }

        public string Make
        {
            get => this.make;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Car make cannot be null or empty.");
                }
                this.make = value;
            }
        }

        public string Model
        {
            get => this.model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Car model cannot be null or empty.");
                }
                this.model = value;
            }
        }

        public string VIN
        {
            get => this.vin;
            private set
            {
                if (value.Length != DefaultVinLenght)
                {
                    throw new ArgumentException("Car VIN must be exactly 17 characters long.");
                }
                this.vin = value;
            }
        }

        public int HorsePower
        {
            get => this.horsePower;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Horse power cannot be below 0.");
                }
                this.horsePower = value;
            }
        }

        public double FuelAvailable
        {
            get => this.fuelAvailable;
            private set
            {
                if (value < 0)
                {
                    this.fuelAvailable = 0;
                }
                this.fuelAvailable = value;
            }
        }
        public double FuelConsumptionPerRace
        {
            get => this.fuelConsumtpionPerRace;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Fuel consumption cannot be below 0.");
                }
                this.fuelConsumtpionPerRace = value;
            }
        }

        public virtual void Drive()
        {
            this.FuelAvailable -= this.FuelConsumptionPerRace;
        }
    }
}
