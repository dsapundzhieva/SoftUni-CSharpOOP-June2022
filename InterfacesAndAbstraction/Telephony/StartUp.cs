namespace Telephony
{
    using Telephony.Core;
    using Telephony.IO;
    using Telephony.IO.Interfaces;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IReader fileReader = new FileReader("../../../data.txt");
            IWriter fileWriter = new FileWriter("../../../result.txt");

            IEngine engine = new Engine(fileReader, fileWriter);
            engine.Start();
        }
    }
}
