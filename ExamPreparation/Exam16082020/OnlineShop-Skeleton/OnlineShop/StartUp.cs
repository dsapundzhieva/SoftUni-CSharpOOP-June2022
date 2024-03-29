﻿using System.IO;
using OnlineShop.Core;
using OnlineShop.IO;

namespace OnlineShop
{
    public class StartUp
    {
        static void Main()
        {
            // Clears output.txt file
            string pathFile = Path.Combine("..", "..", "..", "output.txt");
            File.Create(pathFile).Close();

            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            IController controller = new Controller();
            //controller.AddComputer("Laptop", 1, "A", "B", 1M);
            //controller.AddComponent(1, 2, "PowerSupply", "www", "eee", 111M, 111, 1);
            //controller.AddComponent(1, 3, "PowerSupply", "w", "e", 1M, 1, 2);

            IEngine engine = new Engine(reader, writer, commandInterpreter, controller);
            engine.Run();
        }
    }
}
