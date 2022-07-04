using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();
            list.Add("Pesho1");
            list.Add("Pesho2");
            list.Add("Pesho3");
            list.Add("Pesho4");


            Console.WriteLine(list.RandomString());
        }
    }
}
