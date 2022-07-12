
namespace MilitaryElite.Models
{
    using MilitaryElite.Models.Contracts;
    public class Repair : IRepair
    {

        public Repair(string partName, int houresWorked)
        {
            this.PartName = partName;
            this.HouresWorked = houresWorked;
        }

        public string PartName { get; }
        public int HouresWorked { get; }


        public override string ToString()
        {
            return $"Part Name: {this.PartName} Hours Worked: {this.HouresWorked}";
        }
    }
}
