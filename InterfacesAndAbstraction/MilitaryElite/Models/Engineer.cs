namespace MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Text;
    using MilitaryElite.Enums;

    using MilitaryElite.Models.Contracts;

    internal class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(string firstName, string lastName, int id, decimal salary, Corps corps, ICollection<Repair> repairs) 
            : base(firstName, lastName, id, salary, corps)
        {
            this.Repairs = repairs;
        }

        public ICollection<Repair> Repairs { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());

            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine("Repairs:");

            foreach (var repair in this.Repairs)
            {
                sb.AppendLine($"  {repair}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
