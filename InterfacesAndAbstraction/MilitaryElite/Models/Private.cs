
namespace MilitaryElite.Models
{
    using MilitaryElite.Contracts;

    public class Private : Soldier, IPrivate
    {
        public Private(string firstName, string lastName, int id, decimal salary)
            : base(firstName, lastName, id)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; }

        public override string ToString()
        {
            return base.ToString() + $" Salary: {this.Salary:f2}";
        }
    }
}
