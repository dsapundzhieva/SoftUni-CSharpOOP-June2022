namespace Telephony.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Telephony.Models;
    public class Engine
    {
        private Smartphone smartphone;
        private IList<string> phoneNumbers;
        private IList<string> urls;

        public Engine()
        {
            this.smartphone = new Smartphone();
            this.phoneNumbers = new List<string>();
            this.urls = new List<string>();
        }

        public void Run()
        {
            this.phoneNumbers = Console.ReadLine().Split().ToList();
            this.urls = Console.ReadLine().Split().ToList();

            CallPhoneNumbers();
            BrowseUrls();

        }

        private void BrowseUrls()
        {
            foreach (var url in urls)
            {
                try
                {
                    Console.WriteLine(this.smartphone.Browse(url));
                }
                catch (Exception ae)
                {

                    Console.WriteLine(ae.Message);
                }
            }
        }

        private void CallPhoneNumbers()
        {
            foreach (var number in phoneNumbers)
            {
                try
                {
                    Console.WriteLine(this.smartphone.Call(number));
                }
                catch (Exception ae)
                {

                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
