
namespace P03.BarrackWarsANewFactory.Core
{
    using System;

    using System.Linq;
    using System.Reflection;
    using _03BarracksFactory.Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type cmdType = assembly
                .GetTypes()
                .FirstOrDefault(ct => ct.Name == commandName);

            if (cmdType == null)
            {
                throw new InvalidOperationException("Invalid command type!");
            }

            object instance = Activator.CreateInstance(cmdType);

            MethodInfo executeMethod = cmdType
                .GetMethods()
                .First(m => m.Name.ToLower().Contains(commandName));

            IExecutable result = (IExecutable)executeMethod.Invoke(instance, new object[] { data });

            return result;
        }
    }
}
