namespace WildFarm
{
    using System;
    using Core;
    using Factories.Interfaces;
    using Factories;

    public class StartUp
    {
        static void Main()
        {
            IAnimalFactory animalFactory = new AnimalFactory();
            IFoodFactory foodFactory = new FoodFactory();

            IEngine engine = new Engine(foodFactory, animalFactory);

            engine.Start();
        }
    }
}
