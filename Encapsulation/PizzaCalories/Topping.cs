
namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;

    public class Topping
    {
        private const double BaseCkalPerGram = 2.0;

        private const int MinGramsOfToppings = 1;
        private const int MaxGramsOfToppings = 50;


        private const string ToppingMeat = "meat";
        private const string ToppingVeggie = "veggies";
        private const string ToppingCheese = "cheese";
        private const string ToppingSause = "sauce";

        private const double CkalMeatPerGram = 1.2;
        private const double CkalVeggiesPerGram = 0.8;
        private const double CkalCheesePerGram = 1.1;
        private const double CkalSausePerGram = 0.9;

        private string toppingType;
        private int weight;

        public Topping(string toppingType, int weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;
        }

        public string ToppingType
        {
            get => this.toppingType;
            private set
            {
                if (value.ToLower() != ToppingMeat && value.ToLower() != ToppingVeggie && value.ToLower() != ToppingCheese && value.ToLower() != ToppingSause)
                {
                    throw new ArgumentException(
                        String.Format(ErrorMessages.ToppingInvalidType, value));
                }
                this.toppingType = value;
            }
        }

        public int Weight
        {
            get => this.weight;
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
        {
            double calories = this.weight * BaseCkalPerGram;

            if (this.toppingType.ToLower() == ToppingMeat)
            {
                calories *= CkalMeatPerGram;
            }
            else if (this.toppingType.ToLower() == ToppingVeggie)
            {
                calories *= CkalVeggiesPerGram;
            }
            else if (this.toppingType.ToLower() == ToppingCheese)
            {
                calories *= CkalCheesePerGram;
            }
            else if (this.toppingType.ToLower() == ToppingSause)
            {
                calories *= CkalSausePerGram;
            }
            return calories;
        }
    }
}
