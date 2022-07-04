
using System;

namespace Restaurant
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Fish fish = new Fish("Salmon", 6);
            Console.WriteLine(fish.Grams);

            Soup soup = new Soup("Topcheta", 6, 50);
            Console.WriteLine(soup.Grams);

            Coffee coffee = new Coffee("arabika", 8);
            Console.WriteLine(coffee.Price);
            Console.WriteLine(coffee.Milliliters);

            Console.WriteLine(coffee.Caffeine);

            Cake cake = new Cake("Choko");


        }
    }
}
