
namespace MilitaryElite.Models
{
    using MilitaryElite.Contracts;
    using System.Collections.Generic;
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private readonly List<Private> privates;

        public LieutenantGeneral(string firstName, string lastName, string id, decimal salary) 
            : base(firstName, lastName, id, salary)
        {
            this.privates = new List<Private>();
        }


        IReadOnlyCollection<IPrivate> ILieutenantGeneral.Privates => this.privates;
    }
}
