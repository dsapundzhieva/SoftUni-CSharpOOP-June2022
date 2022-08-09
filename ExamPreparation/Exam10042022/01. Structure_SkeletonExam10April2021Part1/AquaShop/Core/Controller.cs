namespace AquaShop.Core
{
    using AquaShop.Core.Contracts;
    using AquaShop.Models.Aquariums;
    using AquaShop.Models.Aquariums.Contracts;
    using AquaShop.Models.Decorations;
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Repositories;
    using AquaShop.Repositories.Contracts;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using AquaShop.Models.Fish.Contracts;
    using AquaShop.Models.Fish;
    using System.Text;

    public class Controller : IController
    {

        private readonly IRepository<IDecoration> decorations;
        private readonly ICollection<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = aquariumType switch
            {
                nameof(FreshwaterAquarium) => new FreshwaterAquarium(aquariumName),
                nameof(SaltwaterAquarium) => new SaltwaterAquarium(aquariumName),
                _ => throw new InvalidOperationException("Invalid aquarium type.")
            };

            this.aquariums.Add(aquarium);
            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = decorationType switch
            {
                nameof(Ornament) => new Ornament(),
                nameof(Plant) => new Plant(),
                _ => throw new InvalidOperationException("Invalid decoration type.")
            };

            this.decorations.Add(decoration);
            return $"Successfully added {decorationType}.";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var decorationToAdd = this.decorations.FindByType(decorationType);
            if (decorationToAdd == null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }

            var aquariumToAdd = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            aquariumToAdd.AddDecoration(decorationToAdd);
            this.decorations.Remove(decorationToAdd);

            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish = fishType switch
            {
                nameof(FreshwaterFish) => new FreshwaterFish(fishName, fishSpecies, price),
                nameof(SaltwaterFish) => new SaltwaterFish(fishName, fishSpecies, price),
                _ => throw new InvalidOperationException("Invalid fish type.")
            };

            var aquariumToAdd = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            if (aquariumToAdd is FreshwaterAquarium freshwater)
            {
                if (fish is SaltwaterFish)
                {
                    return "Water not suitable.";
                }
                else if (fish is FreshwaterFish)
                {
                    aquariumToAdd.AddFish(fish);
                    return $"Successfully added {fishType} to {aquariumName}.";
                }
            }
            else if (aquariumToAdd is SaltwaterAquarium saltwater)
            {
                if (fish is FreshwaterFish)
                {
                    return "Water not suitable.";
                }
                else if (fish is SaltwaterFish)
                {
                    aquariumToAdd.AddFish(fish);
                    return $"Successfully added {fishType} to {aquariumName}.";
                }
            }

            throw new InvalidOperationException("Add fish method has a bug.");
        }

        public string FeedFish(string aquariumName)
        {
            int fedCount = 0;

            foreach (var aquarium in this.aquariums)
            {
                if (aquarium.Name == aquariumName)
                {
                    foreach (var fish in aquarium.Fish)
                    {
                        fish.Eat();
                        fedCount++;
                    }
                }
            }
            return $"Fish fed: {fedCount}";
        }

        public string CalculateValue(string aquariumName)
        {
            decimal calculateFishPrice = this.aquariums.Select(a => a.Fish.Select(f => f.Price).Sum()).Sum();

            //decimal calculateDecorationPrice = this.decorations.Models.Sum(d => d.Price);
            decimal calculateDecorationPrice = this.aquariums.Select(a => a.Decorations.Select(d => d.Price).Sum()).Sum();

            decimal totalPrice = calculateFishPrice + calculateDecorationPrice;

            return $"The value of Aquarium {aquariumName} is {totalPrice:F2}.";

        }

        public string Report()
        {
            var result = new StringBuilder();

            foreach (var aquarium in this.aquariums)
            {
                result.AppendLine(aquarium.GetInfo());
            }

            return result.ToString().Trim();
        }
    }
}
