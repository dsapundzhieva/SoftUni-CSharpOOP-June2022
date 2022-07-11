
namespace MilitaryElite.Models
{
    using MilitaryElite.Contracts;
    public class Private : Soldier, IPrivate
    {
        private decimal salary;

        public Private(string firstName, string lastName, string id, decimal salary)
            : base(firstName, lastName, id)
        {
            this.Salary = salary;
        }

        public decimal Salary
        {
            get
            {
                return this.salary;
            }
            set
            {
                if (value >= 0)
                {
                    this.salary = value;
                }
            }
        }


    }
}
