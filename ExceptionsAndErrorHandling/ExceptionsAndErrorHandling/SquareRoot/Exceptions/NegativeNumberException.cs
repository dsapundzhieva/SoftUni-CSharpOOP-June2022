namespace SquareRoot.Exceptions
{
    using System;
    internal class NegativeNumberException : Exception
    {

        public const string NegativeNumber = "Invalid number.";
        public NegativeNumberException():
            base(NegativeNumber)
        {

        }
    }
}
