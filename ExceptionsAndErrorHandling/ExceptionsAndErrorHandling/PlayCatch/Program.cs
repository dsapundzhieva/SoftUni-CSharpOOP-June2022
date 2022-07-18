using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayCatch
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int exceptionCount = 0;

            while (exceptionCount < 3)
            {
                var cmdArgs = Console.ReadLine()
                    .Split();
                string cmdType = cmdArgs[0];

                try
                {
                    if (cmdType == "Replace")
                    {
                        int index = int.Parse(cmdArgs[1]);
                        int element = int.Parse(cmdArgs[2]);

                        input[index] = element;
                    }
                    else if (cmdType == "Print")
                    {
                        int startIndex = int.Parse(cmdArgs[1]);
                        int endIndex = int.Parse(cmdArgs[2]);

                        Console.WriteLine(string.Join(", ", input.GetRange(startIndex, endIndex - startIndex + 1)));
                    }
                    else if (cmdType == "Show")
                    {
                        int index = int.Parse(cmdArgs[1]);

                        Console.WriteLine(input[index]);
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid command type!");
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    exceptionCount++;
                    Console.WriteLine("The index does not exist!");
                }
                catch (ArgumentOutOfRangeException)
                {
                    exceptionCount++;
                    Console.WriteLine("The index does not exist!");
                }
                catch (ArgumentException)
                {
                    exceptionCount++;
                    Console.WriteLine("The index does not exist!");
                }
                catch (FormatException)
                {
                    exceptionCount++;
                    Console.WriteLine("The variable is not in the correct format!");
                }
            }

            Console.WriteLine(string.Join(", ", input));
        }
    }
}
