using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var people = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            var products = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, Person> personList = new Dictionary<string, Person>();
            Dictionary<string, Product> productList = new Dictionary<string, Product>();

            try
            {
                foreach (var item in people)
                {
                    var data = item.Split("=", StringSplitOptions.RemoveEmptyEntries);
                    string name = data[0];
                    decimal money = decimal.Parse(data[1]);

                    Person person = new Person(name, money);
                    personList.Add(name, person);
                }

                foreach (var item in products)
                {

                    var data = item.Split("=", StringSplitOptions.RemoveEmptyEntries);
                    string name = data[0];
                    decimal cost = decimal.Parse(data[1]);

                    Product product = new Product(name, cost);
                    productList.Add(name, product);
                }

                string command;

                while ((command = Console.ReadLine()) != "END")
                {
                    var cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string personName = cmdArgs[0];
                    string productName = cmdArgs[1];

                    Person person = personList[personName];
                    Product product = productList[productName];
                    bool isAdded = person.AddProduct(product);

                    if (isAdded)
                    {
                        Console.WriteLine($"{personName} bought {productName}");
                    }
                    else
                    {
                        Console.WriteLine($"{personName} can't afford {productName}");
                    }
                }
                foreach (var (name, person) in personList)
                {
                    if (person.Products.Count > 0)
                    {
                        Console.WriteLine($"{name} - {string.Join(", ", person.Products.Select(x => x.Name))}");
                    }
                    else
                    {
                        Console.WriteLine($"{name} - Nothing bought");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
