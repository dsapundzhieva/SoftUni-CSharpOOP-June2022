
namespace Easter.Core
{
    using Easter.Core.Contracts;
    using Easter.Models.Bunnies;
    using Easter.Models.Bunnies.Contracts;
    using Easter.Models.Dyes;
    using Easter.Models.Eggs;
    using Easter.Models.Eggs.Contracts;
    using Easter.Models.Workshops;
    using Easter.Models.Workshops.Contracts;
    using Easter.Repositories;
    using Easter.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private readonly IRepository<IBunny> bunnies;
        private readonly IRepository<IEgg> eggs;
        private readonly IWorkshop workshop;

        public Controller()
        {
            this.bunnies = new BunnyRepository();
            this.eggs = new EggRepository();
            this.workshop = new Workshop();
        }
        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny = bunnyType switch
            {
                nameof(HappyBunny) => new HappyBunny(bunnyName),
                nameof(SleepyBunny) => new SleepyBunny(bunnyName),
                _ => throw new InvalidOperationException("Invalid bunny type.")
            };

            this.bunnies.Add(bunny);
            return $"Successfully added {bunnyType} named {bunnyName}.";
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            var dye = new Dye(power);
            var bunny = this.bunnies.FindByName(bunnyName);

            if (bunny == null)
            {
                throw new InvalidOperationException("The bunny you want to add a dye to doesn't exist!");
            }

            bunny.AddDye(dye);

            return $"Successfully added dye with power {power} to bunny {bunnyName}!";
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            var egg = new Egg(eggName, energyRequired);

            this.eggs.Add(egg);

            return $"Successfully added egg: {eggName}!";
        }

        public string ColorEgg(string eggName)
        {
            var sortedBunnies = this.bunnies
                .Models
                .Where(b => b.Energy >= 50)
                .OrderByDescending(b => b.Energy)
                .ToList();

            var egg = this.eggs.FindByName(eggName);

            if (sortedBunnies.Count == 0)
            {
                throw new InvalidOperationException("There is no bunny ready to start coloring!");
            }

            foreach (var bunny in sortedBunnies)
            {
                if (bunny.Energy <= 0)
                {
                    this.bunnies.Remove(bunny);
                }
                workshop.Color(egg, bunny);

                if (egg.IsDone())
                {
                    break;
                }
            }
            return $"Egg {eggName} is {(egg.IsDone() ? "done" : "not done")}.";
        }

        public string Report()
        {
            var result = new StringBuilder();

            var coloredEggs = this.eggs
                .Models
                .Where(e => e.IsDone())
                .ToList();

            var bunniesInfo = this.bunnies
                .Models
                .Where(b => b.Energy > 0)
                .ToList();

            result.AppendLine($"{coloredEggs.Count} eggs are done!");
            result.AppendLine("Bunnies info:");

            foreach (var bunny in bunniesInfo)
            {
                var notFinishedDyes = bunny.Dyes.Where(d => !d.IsFinished()).ToList();

                result.AppendLine($"Name: {bunny.Name}");
                result.AppendLine($"Energy: {bunny.Energy}");
                result.AppendLine($"Dyes: {notFinishedDyes.Count} not finished");
            }
            return result.ToString().Trim();
        }
    }
}
