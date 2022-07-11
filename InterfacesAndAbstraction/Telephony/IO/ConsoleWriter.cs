
namespace Telephony.IO
{
    using System;

    using Telephony.IO.Interfaces;
    internal class ConsoleWriter : IWriter
    {
        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
