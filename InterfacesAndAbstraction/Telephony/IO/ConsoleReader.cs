
namespace Telephony.IO
{
    using System;
    using Telephony.IO.Interfaces;
    public class ConsoleReader : IReader

    {
        public string ReadLine()
        {
            string text = Console.ReadLine();
            return text;
        }
    }
}
