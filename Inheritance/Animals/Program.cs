

namespace Animals
{
    using System;
    using System.Collections.Generic;
    public class StartUp
    {
        static void Main(string[] args)
        {
            string animalType;

            List<Animal> animals = new List<Animal>();

            while ((animalType = Console.ReadLine()) != "Beast!")
            {
                try
                {
                    var input = Console.ReadLine().Split();
                    string name = input[0];
                    int age = int.Parse(input[1]);

                    Animal animal = null;
                    if (animalType == "Cat")
                    {
                        string gender = input[2];
                        animal = new Cat(name, age, gender);
                    }
                    else if (animalType == "Dog")
                    {
                        string gender = input[2];
                        animal = new Dog(name, age, gender);
                    }
                    else if (animalType == "Frog")
                    {
                        string gender = input[2];
                        animal = new Frog(name, age, gender);
                    }
                    else if (animalType == "Kitten")
                    {
                        animal = new Kitten(name, age);
                    }
                    else if (animalType == "Tomcat")
                    {
                        animal = new Tomcat(name, age);
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid type!");
                    }
                    animals.Add(animal);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input!");
                }
            }

            foreach (var item in animals)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
