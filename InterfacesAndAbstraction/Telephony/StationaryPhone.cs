namespace Telephony
{
    using System;
    using System.Linq;
    public class StationaryPhone : ICallable
    {
        private string number;
        private string website;
        public StationaryPhone(string number, string website)
        {
            this.number = number;
            this.website = website;
        }

        public string Call(string number)
        {
            if (!number.All(char.IsDigit))
            {
                throw new ArgumentException("Invalid number!");
            }
            if (number.Length == 10)
            {
                return $"Calling... {number}";
            }
            else if (number.Length == 7)
            {
                return $"Dialing... {number}";
            }
            else
            {
                throw new ArgumentException("Invalid number!");
            }
        }
    }
}
