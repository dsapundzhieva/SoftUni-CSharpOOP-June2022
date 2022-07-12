
namespace MilitaryElite.Models
{
    using System.Text;

    using System.Collections.Generic;

    using MilitaryElite.Contracts;

    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(string firstName, string lastName, int id, decimal salary, Dictionary<int, IPrivate> privates) 
            : base(firstName, lastName, id, salary)
        {
            this.Privates = privates;
        }

        public Dictionary<int, IPrivate> Privates { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");

            foreach (var item in this.Privates)
            {
                sb.AppendLine($"  {item.Value}");
            }
                
            return sb.ToString().TrimEnd();
        }
    }
}
