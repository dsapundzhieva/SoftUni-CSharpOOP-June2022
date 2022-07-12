namespace MilitaryElite.Models.Contracts
{
    using MilitaryElite.Contracts;
    using MilitaryElite.Enums;

    public interface ISpecialisedSoldier : IPrivate
    {
        public Corps Corps { get; }
    }
}
