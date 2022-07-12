namespace MilitaryElite.Models.Contracts
{
    public interface IRepair
    {
        string PartName { get; }

        int HouresWorked { get; }
    }
}
