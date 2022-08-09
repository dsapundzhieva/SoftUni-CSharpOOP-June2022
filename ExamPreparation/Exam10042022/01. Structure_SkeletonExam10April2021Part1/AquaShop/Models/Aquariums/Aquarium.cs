namespace AquaShop.Models.Aquariums
{
    using AquaShop.Models.Aquariums.Contracts;
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Fish.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        public Aquarium()
        {
            this.Decorations = new List<IDecoration>();
            this.Fish = new List<IFish>();
        }

        protected Aquarium(string name, int capacity)
            :this()
        {
            this.Name = name;
            this.Capacity = capacity;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Aquarium name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public int Capacity { get; }

        public ICollection<IDecoration> Decorations { get;  }

        public ICollection<IFish> Fish { get;  }

        public int Comfort => this.Decorations.Sum(d => d.Comfort);

        public void AddFish(IFish fish)
        {
            if (this.Fish.Count >= this.Capacity)
            {
                throw new InvalidOperationException("Not enough capacity.");
            }
            this.Fish.Add(fish);
        }

        public bool RemoveFish(IFish fish)
        {
           var fishToRemove = this.Fish.FirstOrDefault(f => f.Name == fish.Name);

            if (fishToRemove == null)
            {
                return false;
            }
            this.Fish.Remove(fishToRemove);
            return true;
        }

        public void AddDecoration(IDecoration decoration) => this.Decorations.Add(decoration);


        public void Feed()
        {
            foreach (var fish in this.Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            var result = new StringBuilder();

            var type = this.GetType().Name;

            result.AppendLine($"{this.Name} ({type}):");

            string allFishes = string.Join(", ", this.Fish.Select(f => f.Name));

            result.AppendLine($"Fish: {(allFishes.Length > 0 ? allFishes : "none")}");
            result.AppendLine($"Decorations: {this.Decorations.Count}");
            result.Append($"Comfort: {this.Comfort}");

            return result.ToString().Trim();
        }

        
    }
}
