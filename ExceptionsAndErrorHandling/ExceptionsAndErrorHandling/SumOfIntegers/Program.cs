using System;
using System.Linq;
using System.Numerics;

namespace SumOfIntegers
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] elements = Console.ReadLine()
                .Split();

            int currentSum = 0;
            int currentNumber;
            BigInteger bigInteger = 0;

            for (int i = 0; i < elements.Length; i++)
            {
                try
                {
                    if (int.TryParse(elements[i], out currentNumber))
                    {
                        currentSum += currentNumber;
                    }
                    else if (BigInteger.TryParse(elements[i] , out bigInteger))
                    {
                        throw new OverflowException();
                    }
                    else
                    {
                        throw new FormatException($"The element '{elements[i]}' is in wrong format!");
                    }
                }
                catch (OverflowException)
                {
                    Console.WriteLine("The element '{0}' is out of range!", elements[i]);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                finally
                {
                    Console.WriteLine($"Element '{elements[i]}' processed - current sum: {currentSum}");
                }
            }
            Console.WriteLine($"The total sum of all integers is: {currentSum}");
        }
    }
}
