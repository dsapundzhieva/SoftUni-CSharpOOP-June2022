namespace MilitaryElite.Models
{
    using System.Text;

    using System.Collections.Generic;

    using MilitaryElite.Enums; 

    using MilitaryElite.Models.Contracts;


    public class Comando : SpecialisedSoldier, IComando
    {
        public Comando(string firstName, string lastName, int id, decimal salary, Corps corps, ICollection<Mission> missions) 
            : base(firstName, lastName, id, salary, corps)
        {
            this.Missions = missions;
        }

        public ICollection<Mission> Missions { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine("Missions:");

            foreach (var mission in this.Missions)
            {
                sb.AppendLine($"  {mission}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
