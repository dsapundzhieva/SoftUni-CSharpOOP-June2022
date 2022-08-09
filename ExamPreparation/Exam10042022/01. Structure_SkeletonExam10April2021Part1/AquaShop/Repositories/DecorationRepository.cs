
namespace AquaShop.Repositories
{
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly List<IDecoration> decorations;

        public DecorationRepository()
        {
            this.decorations = new List<IDecoration>();
        }
        public IReadOnlyCollection<IDecoration> Models => this.decorations.AsReadOnly();

        public void Add(IDecoration model) => this.decorations.Add(model);

        public bool Remove(IDecoration model)
        {
            if (this.decorations.Any(m => m.GetType().Name == model.GetType().Name))
            {
                this.decorations.Remove(model);
                return true;
            }
            return false;
        }

        public IDecoration FindByType(string type)
        {
            return this.decorations.FirstOrDefault(m => m.GetType().Name == type);
        }
    }
}
