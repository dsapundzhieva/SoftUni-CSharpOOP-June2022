
namespace CarRacing.Repositories
{
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class RacerRepository : IRepository<IRacer>
    {
        private readonly List<IRacer> racers;

        public RacerRepository()
        {
            this.racers = new List<IRacer>();
        }
        public IReadOnlyCollection<IRacer> Models => this.racers.AsReadOnly();

        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException("Cannot add null in Racer Repository");
            }
            this.racers.Add(model);
        }

        public bool Remove(IRacer model)
        {
            var racerToBeRemoved = this.racers.FirstOrDefault(r => r.Username == model.Username);

            if (racerToBeRemoved == null)
            {
                return false;
            }
            return true;
        }

        public IRacer FindBy(string property) => this.racers.FirstOrDefault(r => r.Username == property);
    }
}
