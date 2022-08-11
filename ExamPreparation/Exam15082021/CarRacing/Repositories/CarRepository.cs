
namespace CarRacing.Repositories
{
    using System;
    using System.Linq;
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Repositories.Contracts;
    using System.Collections.Generic;

    public class CarRepository : IRepository<ICar>
    {
        private readonly List<ICar> cars;

        public CarRepository()
        {
            this.cars = new List<ICar>();
        }
        public IReadOnlyCollection<ICar> Models => this.cars.AsReadOnly();

        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException("Cannot add null in Car Repository");
            }
            this.cars.Add(model);
        }

        public bool Remove(ICar model)
        {
            var carToBeRemoved = this.cars.FirstOrDefault(c => c.VIN == model.VIN);

            if (carToBeRemoved == null)
            {
                return false;
            }
            return true;
        }

        public ICar FindBy(string property) => this.cars.FirstOrDefault(c => c.VIN == property);
    }
}
