
namespace MilitaryElite.Models.Contracts
{
    using System.Collections.Generic;
    public interface IComando : ISpecialisedSoldier
    {
        ICollection<Mission> Missions { get; }
    }
}
