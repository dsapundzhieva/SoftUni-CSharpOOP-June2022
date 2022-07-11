namespace BorderControl.Models
{
    using BorderControl.Contracts;
    public class Pet : IBirthdable

    {
        public Pet(string name, string birthday)
        {
            this.Birthday = birthday;
            this.Name = name;
        }

        public string Birthday { get ; set ; }

        public string Name { get; private set; }
    }
}
