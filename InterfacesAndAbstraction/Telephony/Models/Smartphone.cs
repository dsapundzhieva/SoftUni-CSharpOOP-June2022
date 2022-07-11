namespace Telephony.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Telephony.Contracts;
    using Telephony.Exceptions;

    internal class Smartphone : ICallable, IBrowsable
    {
        public string Call(string number)
        {
            if (!number.All(c => char.IsDigit(c)))
            {
                throw new ArgumentException(ExceptionMessages.InvalidNumberException);
            }
            return number.Length > 7 ? $"Calling... {number}"
                : $"Dialing... {number}";
        }

        public string Browse(string url)
        {
            if (url.Any(c => char.IsDigit(c)))
            {
                throw new ArgumentException(ExceptionMessages.InvalidUrlException);
            }
            return $"Browsing: {url}!";
        }
    }
}