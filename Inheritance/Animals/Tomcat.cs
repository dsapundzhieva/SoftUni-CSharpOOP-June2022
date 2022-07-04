using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Tomcat : Cat
    {
        private const string DefGender = "Male";

        public Tomcat(string name, int age)
            : base(name, age, "Male")
        {
        }

        protected override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
