using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                var pizzaName = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var doughInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Dough dough = new Dough(doughInput[1], doughInput[2], int.Parse(doughInput[3]));
                Pizza pizza = new Pizza(pizzaName[1], dough);

                string command;

                while ((command = Console.ReadLine()) != "END")
                {
                    var cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    Topping topping = new Topping(cmdArgs[1], int.Parse(cmdArgs[2]));

                    pizza.AddTopping(topping);
                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine(ErrorMessages.NullOrWhitespaceName);
            }
        }
    }
}
