using _03BarracksFactory.Contracts;

namespace P03.BarrackWarsANewFactory.Core.Commands
{
    internal class ReportCommand : Command
    {
        private readonly IRepository repository;
        private readonly IUnitFactory unitFactory;
        public ReportCommand(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string output = this.repository.Statistics;
            return output;
        }
    }
}
