

namespace Easter.Models.Bunnies
{
    using System;
    using Easter.Models.Bunnies.Contracts;
    using Easter.Models.Dyes.Contracts;
    using System.Collections.Generic;
    public abstract class Bunny : IBunny
    {
        private string name;
        private int energy;

        public Bunny()
        {
            this.Dyes = new List<IDye>();
        }
        protected Bunny(string name, int energy)
            :this()
        {
            this.Name = name;
            this.Energy = energy;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Bunny name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public int Energy
        {
            get => this.energy;
            protected set
            {
                if (value <= 0)
                {
                    this.energy = 0;
                }
                this.energy = value;
            }
        }

        public ICollection<IDye> Dyes { get; }

        public void AddDye(IDye dye) => this.Dyes.Add(dye);

        public abstract void Work();
    }
}
