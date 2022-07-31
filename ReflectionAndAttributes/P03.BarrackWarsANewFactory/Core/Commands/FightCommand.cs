
namespace P03.BarrackWarsANewFactory.Core.Commands
{
    using System;
    using _03BarracksFactory.Contracts;
    internal class FightCommand : Command
    {
        private readonly IRepository repository;
        private readonly IUnitFactory unitFactory;
        private const int exitSuccessfully = 0;
        public FightCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            Environment.Exit(exitSuccessfully);
            return null;
        }
    }
}
