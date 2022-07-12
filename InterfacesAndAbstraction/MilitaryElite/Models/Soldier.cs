namespace MilitaryElite.Models
{
    using MilitaryElite.Contracts;

    public class Soldier : ISoldier
    {
        public Soldier(string firstName, string lastName, int id)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id}";
        }
    }
}
