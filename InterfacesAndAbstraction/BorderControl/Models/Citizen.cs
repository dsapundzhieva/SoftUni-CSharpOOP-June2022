namespace BorderControl.Models
{
    using BorderControl.Contracts;
    using System.Collections.Generic;
    public class Citizen : IIdentifiable, IBirthdable, IBuyer
    {
        private readonly List<string> ids;

        public Citizen(string name, int age, string id, string birthday)
        {
            this.ids = new List<string>();
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.Birthday = birthday;
            this.Food = 0;
        }

        public string Id { get; set; }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Birthday { get ; set ; }

        public IReadOnlyCollection<string> IDs => ids;

        public int Food { get; set; }

        public void BuyFood()
        {
            this.Food += 10;
        }

        private void AddId()
        {
            if (Id.Length == 10)
            {
                ids.Add(Id);
            }
        }
    }
}
