namespace WildFarm.Core
{
    using Factories.Interfaces;
    using System;
    using System.Collections.Generic;
    using Models.Animals;
    using Models.Foods;
    using Exceptions;

    public class Engine : IEngine
    {
        private readonly IFoodFactory foodFactory;
        private readonly IAnimalFactory animalFactory;

        private readonly ICollection<Animal> animals;

        public Engine()
        {
            this.animals = new List<Animal>();
        }

        public Engine(IFoodFactory foodFactory, IAnimalFactory animalFactory)
            :this()
        {
            this.foodFactory = foodFactory;
            this.animalFactory = animalFactory;
        }

        public void Start()
        {
            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] animalInfo = command
                   .Split();

                    string[] foodInfo = Console.ReadLine()
                        .Split();

                    Animal animal = BuildAnimalUsingFactory(animalInfo);
                    Food food = foodFactory.CreateFoodFactory(foodInfo[0], int.Parse(foodInfo[1]));

                    Console.WriteLine(animal.ProduceSound());

                    this.animals.Add(animal);

                    animal.Eat(food);
                }
                catch (InvalidFactoryTypeException ifte)
                {
                    Console.WriteLine(ifte.Message);
                }
                catch (InvalidTypeOfFood itof)
                {
                    Console.WriteLine(itof.Message);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
            
        }

        private Animal BuildAnimalUsingFactory(string[] animalInfo)
        {
            Animal animal;

            if (animalInfo.Length == 4)
            {
                animal = this.animalFactory.CreateAnimalFactory(animalInfo[0], animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3]);
            }
            else if (animalInfo.Length == 5)
            {
                animal = this.animalFactory.CreateAnimalFactory(animalInfo[0], animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3], animalInfo[4]);
            }
            else
            {
                throw new ArgumentException("Invalid input!");
            }
            return animal;
        }
    }
}
