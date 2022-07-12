
namespace MilitaryElite.Models.Contracts
{
    using System.Collections.Generic;
    public interface IEngineer : ISpecialisedSoldier
    {
        ICollection<Repair> Repairs { get; }
    }
}
