
namespace Raiding
{
    using Factories.Interfaces;
    using Factories;
    using System;
    using Core;
    using IO.Interfaces;
    using IO;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IFactoryHero factoryHero = new FactoryHero();

            Engine engine = new Engine(factoryHero, reader, writer);

            engine.Start();
        }
    }
}
