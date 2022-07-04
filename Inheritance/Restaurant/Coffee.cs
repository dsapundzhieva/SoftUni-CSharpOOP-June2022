using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {

        private const double DefCoffeeMilliliters = 50;
        private const decimal DefCoffeePrice = 3.50m;

        public Coffee(string name, double caffeine)
            : base(name, DefCoffeePrice, DefCoffeeMilliliters)
        {
            this.Caffeine = caffeine;
        }
        public double Caffeine { get; set; }
    }
}
