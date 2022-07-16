namespace Vehicles.Exceptions
{
    using System;
    internal class NegativeFuelException : Exception
    {
        private const string DefaultMessage = "Fuel must be a positive number";

        public NegativeFuelException()
            : base(DefaultMessage)
        {

        }
    }
}
