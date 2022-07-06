using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var inputPizza = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var inputDough = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            try
            {
                Dough dough = new Dough(inputDough[1], inputDough[2], int.Parse(inputDough[3]));
                Pizza pizza = new Pizza(inputPizza[1], dough);

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