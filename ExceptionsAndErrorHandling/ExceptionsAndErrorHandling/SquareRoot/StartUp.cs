
namespace SquareRoot
{
    using global::SquareRoot.Exceptions;
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            
            try
            {
                int number = int.Parse(Console.ReadLine());
                SquareRoot squareRoot = new SquareRoot(number);
                Console.WriteLine(squareRoot.CalculateSquareRoot());
            }
            catch (NegativeNumberException nne)
            {
                Console.WriteLine(nne.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }

        }
    }
}
