
namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;

    public class Dough
    {
        private const double BaseCkalPerGram = 2.0;
        private const int minWeight = 1;
        private const int maxWeight = 200;


        private readonly Dictionary<string, double> modifiers = new Dictionary<string, double>()
        {
            { "white", 1.5},
            { "wholegrain", 1.0},
            { "crispy", 0.9},
            { "chewy", 1.1},
            { "homemade", 1.0},
        };

        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get
            {
                return this.flourType;
            }
            private set
            {
                if (!this.modifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(ErrorMessages.DoughInavlidValue);
                }
                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            private set
            {
                if (!this.modifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(ErrorMessages.DoughInavlidValue);
                }
                this.bakingTechnique = value;
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
                if (value < minWeight || value > maxWeight)
                {
                    throw new ArgumentException(ErrorMessages.DoughInavlidWeight);
                }
                this.weight = value;
            }
        }

        public double CalculateDoughCaloriesPerGram()
        => this.weight * BaseCkalPerGram * this.modifiers[FlourType.ToLower()] * this.modifiers[BakingTechnique.ToLower()];
    }
}
