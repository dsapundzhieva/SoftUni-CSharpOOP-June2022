
namespace P03.BarrackWarsANewFactory.Core.Commands
{
    using _03BarracksFactory.Contracts;
    internal class AddCommand : Command
    {
        private readonly IRepository repository;
        private readonly IUnitFactory unitFactory;

        public AddCommand(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string unitType = Data[1];
            IUnit unitToAdd = this.unitFactory.CreateUnit(unitType);
            this.repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }
    }
}
