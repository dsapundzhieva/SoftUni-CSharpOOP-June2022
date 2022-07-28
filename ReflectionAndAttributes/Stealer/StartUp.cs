namespace Stealer
{
    using System;
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.CollectGetterAndSetters("Stealer.Hacker");
            Console.WriteLine(result);
        }
    }
}
