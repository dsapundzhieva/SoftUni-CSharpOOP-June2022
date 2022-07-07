namespace Telephony
{
    using System;
    using System.Collections.Generic;
    using Telephony.Contracts;
    using Telephony.Core;
    using Telephony.Models;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
