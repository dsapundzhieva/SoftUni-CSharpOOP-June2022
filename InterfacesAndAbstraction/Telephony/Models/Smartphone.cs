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
            foreach (char num in number)
            {
                if (!char.IsDigit(num))
                {
                    return "Invalid number!";
                }
            }
            return $"Calling... {number}";
        }

        public string Browse(string url)
        {
            foreach (char website in url)
            {
                if (char.IsDigit(website))
                {
                    return "Invalid URL!";
                }
            }
            return $"Browsing: {url}!";
        }
    }
}