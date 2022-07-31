namespace _03BarracksFactory
{
    using Contracts;
    using Core;
    using Core.Factories;
    using Data;
    using P03.BarrackWarsANewFactory.Core;

    class AppEntryPoint
    {
        static void Main(string[] args)
        {
            IRepository repository = new UnitRepository();
            IUnitFactory unitFactory = new UnitFactory();
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            IRunnable engine = new Engine(commandInterpreter, repository, unitFactory);
            engine.Run();
        }
    }
}
