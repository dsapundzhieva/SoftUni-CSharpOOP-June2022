namespace WildFarm.Core
{
    using System;
    using Factories.Interfaces;
    using System.Collections.Generic;
    using Models.Animals;
    using Models.Foods;
    using Exceptions;
    using IO.Interfaces;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly IFoodFactory foodFactory;
        private readonly IAnimalFactory animalFactory;

        private readonly ICollection<Animal> animals;

        public Engine()
        {
            this.animals = new List<Animal>();
        }

        public Engine(IFoodFactory foodFactory, IAnimalFactory animalFactory, IReader reader, IWriter writer)
            :this()
        {
            this.foodFactory = foodFactory;
            this.animalFactory = animalFactory;
            this.reader = reader;
            this.writer = writer;
        }

        public void Start()
        {
            string command;

            while ((command = reader.ReadLine()) != "End")
            {
                try
                {
                    string[] animalInfo = command
                   .Split();

                    string[] foodInfo = reader.ReadLine()
                        .Split();

                    Animal animal = BuildAnimalUsingFactory(animalInfo);
                    Food food = foodFactory.CreateFoodFactory(foodInfo[0], int.Parse(foodInfo[1]));

                    writer.WriteLine(animal.ProduceSound());

                    this.animals.Add(animal);

                    animal.Eat(food);
                }
                catch (InvalidFactoryTypeException ifte)
                {
                    writer.WriteLine(ifte.Message);
                }
                catch (InvalidTypeOfFood itof)
                {
                    writer.WriteLine(itof.Message);
                }
                catch (ArgumentException ae)
                {
                    writer.WriteLine(ae.Message);
                }
            }

            foreach (var animal in animals)
            {
                writer.WriteLine(animal.ToString());
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
