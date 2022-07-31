
namespace P02.BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;
    public class BlackBoxIntegerTests
    {
        static void Main(string[] args)
        {
            Type classType = typeof(BlackBoxInteger);

            MethodInfo[] methods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            var instance = Activator.CreateInstance(classType, true);

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                var cmdArgs = command.Split("_");

                string methodName = cmdArgs[0];
                int methodValue = int.Parse(cmdArgs[1]);

                MethodInfo currMethod = methods.FirstOrDefault(m => m.Name == methodName);
                currMethod.Invoke(instance, new object[] { methodValue });

                var innerValue = classType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(iv => iv.Name == "innerValue").GetValue(instance);
                Console.WriteLine(innerValue);
            }
        }
    }
}
