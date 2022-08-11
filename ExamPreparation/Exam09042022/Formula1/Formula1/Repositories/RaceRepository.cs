
namespace Formula1.Repositories
{
    using System.Linq;
    using Formula1.Models.Contracts;
    using Formula1.Repositories.Contracts;
    using System.Collections.Generic;

    public class RaceRepository : IRepository<IRace>
    {
        private readonly List<IRace> races;

        public RaceRepository()
        {
            this.races = new List<IRace>();
        }

        public IReadOnlyCollection<IRace> Models => this.races.AsReadOnly();

        public void Add(IRace model) => this.races.Add(model);

        public bool Remove(IRace model)
        {
            var raceToBeRemoved = this.races.FirstOrDefault(r => r.RaceName == model.RaceName);

            if (raceToBeRemoved == null)
            {
                return false;
            }
            this.races.Remove(raceToBeRemoved);
            return true;
        }

        public IRace FindByName(string name) => this.races.FirstOrDefault(r => r.RaceName == name);
    }
}
