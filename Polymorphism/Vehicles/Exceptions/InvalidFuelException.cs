
namespace Vehicles.Exceptions
{
    using System;
    public class InvalidFuelException : Exception
    {
        public InvalidFuelException(string message)
            : base(message)
        {

        }
    }
}
