
namespace P03.BarrackWarsANewFactory.Core.Commands
{
    using _03BarracksFactory.Contracts;
    public abstract class Command : IExecutable
    {
        private string[] data;
        private IRepository repository;
        private IUnitFactory unitFactory;

        protected Command(string[] data, IRepository repository, IUnitFactory unitFactory)
        {
            this.Data = data;
            this.Repository = repository;
            this.UnitFactory = unitFactory;
        }

        public string[] Data 
        {
            get { return this.data; }
            private set { this.data = value; } 
        }
        public IRepository Repository
        {
            get { return this.repository; }
            private set { this.repository = value; }
        }
        public IUnitFactory UnitFactory
        {
            get { return this.unitFactory; }
            private set { this.unitFactory = value; }
        }

        public abstract string Execute();
    }
}
