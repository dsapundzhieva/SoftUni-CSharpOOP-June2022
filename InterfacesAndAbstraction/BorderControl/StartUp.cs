namespace BorderControl
{
    using BorderControl.Contracts;
    using BorderControl.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, IBuyer> peopleBuyeList = new Dictionary<string, IBuyer>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var commandArgs = Console.ReadLine().Split();

                IBuyer buyer = null;
                string name = commandArgs[0];

                if (!peopleBuyeList.ContainsKey(name))
                {
                    int age = int.Parse(commandArgs[1]);

                    if (commandArgs.Length == 4)
                    {
                        string id = commandArgs[2];
                        string birthday = commandArgs[3];
                        buyer = new Citizen(name, age, id, birthday);
                    }
                    else if (commandArgs.Length == 3)
                    {
                        string group = commandArgs[2];
                        buyer = new Rebel(name, age, group);
                    }
                    peopleBuyeList.Add(name, buyer);
                } 
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string name = command;

                if (peopleBuyeList.ContainsKey(name))
                {
                    peopleBuyeList[name].BuyFood();
                }
              
            }

            Console.WriteLine(peopleBuyeList.Sum(p => p.Value.Food));
        }
    }
}
