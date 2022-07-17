namespace WildFarm
{
    using Core;
    using Factories.Interfaces;
    using Factories;
    using IO.Interfaces;
    using IO;

    public class StartUp
    {
        static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IReader fileReader = new FileReader("../../../readData.txt");
            IWriter fileWriter = new FileWriter("../../../resultData.txt");

            IAnimalFactory animalFactory = new AnimalFactory();
            IFoodFactory foodFactory = new FoodFactory();

            IEngine engine = new Engine(foodFactory, animalFactory, fileReader, fileWriter);

            engine.Start();
        }
    }
}
