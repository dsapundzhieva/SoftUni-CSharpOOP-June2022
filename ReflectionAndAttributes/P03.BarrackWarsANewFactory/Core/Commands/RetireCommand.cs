
namespace P03.BarrackWarsANewFactory.Core.Commands
{
    using _03BarracksFactory.Contracts;
    public class RetireCommand : Command
    {
        private readonly IRepository repository;
        private readonly IUnitFactory unitFactory;
        public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string unitType = Data[1];
            this.repository.RemoveUnit(unitType);
            string output = unitType + " retired!";
            return output;
        }
    }
}
