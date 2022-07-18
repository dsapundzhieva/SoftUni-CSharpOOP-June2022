namespace EnterNumbers
{
    using System;
    using System.Collections.Generic;

    internal class StartUp
    {
        static void Main(string[] args)
        {

            int start = 1;
            int end = 100;
            List<int> nums = ReadNumber(start, end);

            Console.WriteLine(string.Join(", ", nums));
        }

        static List<int> ReadNumber(int start, int end)
        {
            List<int> numbers = new List<int>();
            int currentNumber = 1;

            while (numbers.Count < 10)
            {
                try
                {
                    string readNumber = Console.ReadLine();

                    if (int.TryParse(readNumber, out currentNumber))
                    {
                        if (currentNumber <= start || currentNumber > end)
                        {
                            throw new ArgumentException($"Your number is not in range {start} - 100!");
                        }
                        else
                        {
                            numbers.Add(currentNumber);
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Invalid Number!");
                    }
                    start = currentNumber;
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            return numbers;
        }
    }
}
