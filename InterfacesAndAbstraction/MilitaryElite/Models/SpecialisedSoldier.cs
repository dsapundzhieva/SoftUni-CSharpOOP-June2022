using MilitaryElite.Enums;
using MilitaryElite.Models.Contracts;

namespace MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(string firstName, string lastName, int id, decimal salary, Corps corps)
            : base(firstName, lastName, id, salary)
        {
            this.Corps = corps;
        }

        public Corps Corps { get; }
    }
}
