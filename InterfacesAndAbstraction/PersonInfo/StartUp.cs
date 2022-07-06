namespace PersonInfo
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string id = Console.ReadLine();
            string birthday = Console.ReadLine();

            IIdentifiable identifiable = new Citizen(name, age, id, birthday);
            IBirthable birthable = new Citizen(name, age, id, birthday);

            Console.WriteLine(identifiable.Id);
            Console.WriteLine(birthable.Birthdate);
        }
    }
}
