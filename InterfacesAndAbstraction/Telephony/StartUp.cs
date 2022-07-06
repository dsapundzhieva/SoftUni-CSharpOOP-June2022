namespace Telephony
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Queue<string> numbers = new Queue<string>(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries));
            Queue<string> websites = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));

            while (numbers.Count > 0)
            {
                try
                {

                }
                catch (Exception)
                {

                    throw;
                }
            }

        }
    }
}
