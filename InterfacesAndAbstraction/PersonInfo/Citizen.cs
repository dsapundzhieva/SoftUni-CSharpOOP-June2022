namespace PersonInfo
{
    public class Citizen : IPerson, IBirthable, IIdentifiable
    {

        public Citizen(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthday;
        }

        public string Name { get ; set ; }
        public int Age { get ; set ; }
        public string Id { get; set; }
        public string Birthdate { get; set; }
    }
}
