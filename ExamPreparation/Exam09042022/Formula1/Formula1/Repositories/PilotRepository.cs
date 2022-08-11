
namespace Formula1.Repositories
{
    using System.Linq;
    using Formula1.Models.Contracts;
    using Formula1.Repositories.Contracts;
    using System.Collections.Generic;

    public class PilotRepository : IRepository<IPilot>
    {
        private readonly List<IPilot> pilots;

        public PilotRepository()
        {
            this.pilots = new List<IPilot>();
        }

        public IReadOnlyCollection<IPilot> Models => this.pilots.AsReadOnly();

        public void Add(IPilot model) => this.pilots.Add(model);

        public bool Remove(IPilot model)
        {
            var pilotToBeRemoved = this.pilots.FirstOrDefault(p => p.FullName == model.FullName);
            if (pilotToBeRemoved == null)
            {
                return false;
            }
            this.pilots.Remove(pilotToBeRemoved);
            return true;
        }

        public IPilot FindByName(string name) => this.pilots.FirstOrDefault(p => p.FullName == name);
    }
}
