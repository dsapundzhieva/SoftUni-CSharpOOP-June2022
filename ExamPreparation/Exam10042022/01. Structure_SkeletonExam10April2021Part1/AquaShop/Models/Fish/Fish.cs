
namespace AquaShop.Models.Fish
{
    using System;
    using AquaShop.Models.Fish.Contracts;

    public abstract class Fish : IFish
    {
        private string name;
        private string species;
        private decimal price;
        private int size;

        protected Fish(string name, string species, decimal price)
        {
            this.Name = name;
            this.Species = species;
            this.Price = price;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Fish name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public string Species
        {
            get => this.species;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Fish species cannot be null or empty.");
                }
                this.species = value;
            }
        }

        public int Size
        {
            get => this.size;
            protected set
            {
                this.size = value;
            }
        }

        public decimal Price
        {
            get => this.price;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Fish price cannot be below or equal to 0.");
                }
                this.price = value;
            }
        }

        public abstract void Eat();
    }
}
