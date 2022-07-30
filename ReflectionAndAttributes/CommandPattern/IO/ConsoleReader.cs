
namespace CommandPattern.IO
{
    using System;

    using CommandPattern.IO.Contracts;
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            string line = Console.ReadLine();
            return line;
        }
    }
}
