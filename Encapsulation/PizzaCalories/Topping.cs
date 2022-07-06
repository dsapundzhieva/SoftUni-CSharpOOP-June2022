
namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;

    public class Topping
    {
        private const double BaseCkalPerGram = 2.0;
        private const int MinGramsOfToppings = 1;
        private const int MaxGramsOfToppings = 50;

        Dictionary<string, double> modifiers = new Dictionary<string, double>()
        {
            { "meat", 1.2},
            { "veggies", 0.8},
            { "cheese", 1.1},
            { "sauce", 0.9}
        };

        private string toppingType;
        private int weight;

        public Topping(string toppingType, int weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;
        }

        public string ToppingType
        {
            get
            {
                return this.toppingType;
            }
            private set
            {
                if (!this.modifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(
                        String.Format(ErrorMessages.ToppingInvalidType, value));
                }
                this.toppingType = value;
            }
        }

        public int Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value < MinGramsOfToppings || value > MaxGramsOfToppings)
                {
                    throw new ArgumentException(
                        String.Format(ErrorMessages.ToppingInvalidWeight, this.ToppingType));
                }
                this.weight = value;
            }
        }

        public double CalculateToppingCaloriesPerGram()
        => this.weight * BaseCkalPerGram * this.modifiers[ToppingType.ToLower()];
    }
}
