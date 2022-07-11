
namespace Telephony.Models
{
    using Telephony.Contracts;
    public class StationaryPhone : ICallable
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
            return $"Dialing... {number}";
        }
    }
}
