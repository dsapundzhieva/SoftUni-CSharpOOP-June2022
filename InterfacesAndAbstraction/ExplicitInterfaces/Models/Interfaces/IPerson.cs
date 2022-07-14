namespace ExplicitInterfaces.Models.Interfaces
{
    public interface IPerson
    {
        public string Name { get; }
        int Age { get; }

        public string GetName();
    }
}
