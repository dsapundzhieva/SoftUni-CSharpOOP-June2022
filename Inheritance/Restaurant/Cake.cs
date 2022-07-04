using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    internal class Cake : Dessert
    {
        private const int DefGrams = 250;
        private const int DefCalories = 1000;
        private const int DefCakePrice = 5;


        public Cake(string name) : base(name, DefCakePrice, DefGrams, DefCalories)
        {

        }
    }
}
