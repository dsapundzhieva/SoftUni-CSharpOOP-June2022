namespace Vehicles.Models
{
    using Interfaces;
    using System;
    using Vehicles.Exceptions;

    public abstract class Vehicle : IVehicle
    {

        private double fuelConsumption;
        private double fuelQuantity;
        private double tankCapacity;

        private Vehicle()
        {
            this.FuelConsumprionModifier = 0;
        }
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
            :this()
        {
            this.FuelQuantity = fuelQuantity > tankCapacity ? 0 : fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }

        public double FuelQuantity 
        {
            get
            {
                return this.fuelQuantity;
            }
            protected set
            {
                this.fuelQuantity = value;
            }
        }

        public double FuelConsumption 
        {
            get
            {
                return this.fuelConsumption;
            }
            protected set
            {
                this.fuelConsumption = value + this.FuelConsumprionModifier;
            }
        }

        protected virtual double FuelConsumprionModifier { get; }

        public double TankCapacity 
        {
            get
            {
                return this.tankCapacity;
            }
            protected set
            {
                this.tankCapacity = value;
            }
        }

        public string Drive(double distance)
        {
            double neededFuel = this.FuelConsumption * distance;

            if (this.FuelQuantity < neededFuel)
            {
                return $"{this.GetType().Name} needs refueling";
            }
            this.FuelQuantity -= neededFuel;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double fuelQuantity)
        {
            if (fuelQuantity <= 0)
            {
                throw new NegativeFuelException();
            }
            if (fuelQuantity + this.FuelQuantity > this.TankCapacity)
            {
                throw new InvalidFuelException(
                    String.Format(ExeptionMessages.InvalidFuelAmount, fuelQuantity));
            }
            this.FuelQuantity += fuelQuantity;
        }
        public string DriveEmpty(double distance)
        {
            var fuelConsump = this.FuelConsumption - 1.4;
            double neededFuel = fuelConsump * distance;

            if (this.FuelQuantity < neededFuel)
            {
                return $"{this.GetType().Name} needs refueling";
            }
            this.FuelQuantity -= neededFuel;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.fuelQuantity:f2}";
        }
    }
}
