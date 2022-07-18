
using SquareRoot.Exceptions;
using System;

namespace SquareRoot
{
    public class SquareRoot
    {
        private int number;
        public SquareRoot(int number)
        {
            Number = number;
        }

        public int Number
        {
            get
            {
                return this.number;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new NegativeNumberException();
                }
                this.number = value;
            }
        }

        public int CalculateSquareRoot()
        { 
            return (int)Math.Sqrt(this.Number);
        }
    }
}
