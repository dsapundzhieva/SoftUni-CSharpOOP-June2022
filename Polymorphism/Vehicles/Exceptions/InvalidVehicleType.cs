namespace Vehicles.Exceptions
{
    using System;
    public class InvalidVehicleType : Exception
    {
        private const string InvalidTypeDefaultMessage = "Ivalid vehicle type!";
        public InvalidVehicleType()
            :base(InvalidTypeDefaultMessage)
        {

        }
    }
}
