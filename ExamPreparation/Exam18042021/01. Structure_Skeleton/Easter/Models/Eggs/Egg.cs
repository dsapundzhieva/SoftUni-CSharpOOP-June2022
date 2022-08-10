
namespace Easter.Models.Eggs
{
    using Easter.Models.Eggs.Contracts;
    using System;

    public class Egg : IEgg
    {
        private const int DeffEggEnergyDecreaser = 10;
        private string name;
        private int energyRequired;


        public Egg(string name, int energyRequired)
        {
            this.Name = name;
            this.EnergyRequired = energyRequired;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Egg name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public int EnergyRequired
        {
            get => this.energyRequired;
            private set
            {
                if (value < 0)
                {
                    this.energyRequired = 0;
                }
                this.energyRequired = value;
            }
        }

        public void GetColored()
        {
            if (this.EnergyRequired < 0)
            {
                this.EnergyRequired = 0;
            }
            this.EnergyRequired -= DeffEggEnergyDecreaser;
        }

        public bool IsDone() => this.EnergyRequired == 0;
    }
}
