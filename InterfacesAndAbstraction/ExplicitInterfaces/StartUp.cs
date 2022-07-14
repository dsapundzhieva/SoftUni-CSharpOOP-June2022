
namespace ExplicitInterfaces
{
    using ExplicitInterfaces.Models;
    using ExplicitInterfaces.Models.Interfaces;
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command;

            IPerson person;
            IResident resident;

            while ((command = Console.ReadLine()) != "End")
            {
                var cmdArgs = command.Split();

                string name = cmdArgs[0];
                string country = cmdArgs[1];
                int age = int.Parse(cmdArgs[2]);

                person = new Citizen(name, country, age);
                resident = new Citizen(name, country, age);

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
