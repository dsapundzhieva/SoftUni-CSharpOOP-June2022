
namespace Easter.Repositories
{
    using Easter.Models.Eggs.Contracts;
    using Easter.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class EggRepository : IRepository<IEgg>
    {
        private readonly List<IEgg> eggs;

        public EggRepository()
        {
            this.eggs = new List<IEgg>();
        }
        public IReadOnlyCollection<IEgg> Models => this.eggs.AsReadOnly();

        public void Add(IEgg model) => this.eggs.Add(model);

        public bool Remove(IEgg model)
        {
            var eggToBeRemoved = this.eggs.FirstOrDefault(b => b.Name == model.Name);

            if (eggToBeRemoved == null)
            {
                return false;
            }
            this.eggs.Remove(model);
            return true;
        }

        public IEgg FindByName(string name)
        {
            return this.eggs.FirstOrDefault(b => b.Name == name);
        }
    }
}
