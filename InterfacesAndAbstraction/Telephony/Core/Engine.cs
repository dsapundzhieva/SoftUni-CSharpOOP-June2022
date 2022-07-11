namespace Telephony.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Telephony.IO.Interfaces;
    using Telephony.Models;
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly Smartphone smartphone;
        private readonly StationaryPhone stationaryPhone;

        public Engine()
        {
            this.smartphone = new Smartphone();
            this.stationaryPhone = new StationaryPhone();
        }

        public Engine(IReader reader, IWriter writer)
            :this()
        {
            this.reader = reader;
            this.writer = writer;
        }


        public void Start()
        {
            
            string[] phoneNumbers = this.reader.ReadLine().Split().ToArray();
            string[] urls = this.reader.ReadLine().Split().ToArray();

            foreach (var number in phoneNumbers)
            {
                if (number.Length == 7)
                {
                    this.writer.WriteLine(stationaryPhone.Call(number));
                }
                else if (number.Length == 10)
                {
                    this.writer.WriteLine(smartphone.Call(number));
                }
            }

            foreach (var url in urls)
            {
                this.writer.WriteLine(smartphone.Browse(url));
            }
        }
    }
}
