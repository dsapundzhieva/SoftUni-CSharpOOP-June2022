
namespace CommandPattern.Core
{
    using CommandPattern.Core.Contracts;
    using CommandPattern.IO.Contracts;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        private readonly IReader consoleReader;
        private readonly IWriter consoleWriter;

        public Engine(ICommandInterpreter commandInterpreter, IReader consoleReader, IWriter consoleWriter)
        {
            this.commandInterpreter = commandInterpreter;
            this.consoleReader = consoleReader;
            this.consoleWriter = consoleWriter;
        }

        public void Run()
        {
            while (true)
            {
                string input = this.consoleReader.ReadLine();

                string result = this.commandInterpreter.Read(input);
                this.consoleWriter.WriteLine(result);
            }
        }
    }
}
