

namespace Easter.Repositories
{
    using Easter.Models.Bunnies.Contracts;
    using Easter.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class BunnyRepository : IRepository<IBunny>
    {
        private readonly List<IBunny> bunnies;
        public BunnyRepository()
        {
            this.bunnies = new List<IBunny>();
        }

        public IReadOnlyCollection<IBunny> Models => this.bunnies.AsReadOnly();

        public void Add(IBunny model) => this.bunnies.Add(model);

        public bool Remove(IBunny model)
        {
            var bunnyToBeRemoved = this.bunnies.FirstOrDefault(b => b.Name == model.Name);

            if (bunnyToBeRemoved == null)
            {
                return false;
            }
            this.bunnies.Remove(model);
            return true;
        }

        public IBunny FindByName(string name)
        {
            return this.bunnies.FirstOrDefault(b => b.Name == name);
        }
    }
}
