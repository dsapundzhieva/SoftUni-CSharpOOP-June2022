namespace Telephony
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    internal class Smartphone : ICallable, IBrowsable
    {
        private string number;
        private string website;

        public Smartphone(string number)
        {
            this.number = number;
            this.website = website;
        }

        public string Browse(string website)
        {
            if (!website.All(char.IsLetter))
            {
                throw new ArgumentException("Invalid URL!");
            }
            return $"Browsing: {website}!";
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

