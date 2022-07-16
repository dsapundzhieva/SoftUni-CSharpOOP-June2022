
namespace Raiding.Core
{
    using Models;
    using Factories.Interfaces;
    using System.Collections.Generic;
    using Exceptions;
    using IO.Interfaces;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly ICollection<BaseHero> heroes;
        private readonly IFactoryHero heroFactory;

        public Engine()
        {
            this.heroes = new List<BaseHero>();
        }

        public Engine(IFactoryHero hero, IReader reader, IWriter writer)
            :this()
        {
            this.reader = reader;
            this.writer = writer;
            this.heroFactory = hero;
        }
       
        public void Start()
        {
            int numberOfCmds = int.Parse(reader.ReadLine());

            for (int i = 0; i < numberOfCmds; i++)
            {
                try
                {
                    string name = reader.ReadLine();
                    string type = reader.ReadLine();

                    BaseHero hero = this.heroFactory.CreateHero(name, type);
                    this.heroes.Add(hero);
                   
                }
                catch (InvalidHeroType iht)
                {
                    writer.WriteLine(iht.Message);
                    i--;
                }
            }

            int bossPower = int.Parse(reader.ReadLine());
            int sum = 0;
            foreach (var hero in heroes)
            {
                sum += hero.Power;
                writer.WriteLine(hero.CastAbility());
            }

            if (sum >= bossPower)
            {
                writer.WriteLine("Victory!");
            }
            else
            {
                writer.WriteLine("Defeat...");
            }
        }
    }
}
