namespace WildFarm.Exceptions
{
    using System;
    public class InvalidTypeOfFood : Exception
    {
        public InvalidTypeOfFood(string message)
            : base(message)
        {

        }
    }
}
