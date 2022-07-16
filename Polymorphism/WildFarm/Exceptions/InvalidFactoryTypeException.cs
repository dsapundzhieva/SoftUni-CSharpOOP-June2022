
namespace WildFarm.Exceptions
{
    using System;
    public class InvalidFactoryTypeException : Exception
    {
        private const string InvalidType = "Invalid Type!"; 
        public InvalidFactoryTypeException()
            : base(InvalidType)
        {

        }
    }
}
