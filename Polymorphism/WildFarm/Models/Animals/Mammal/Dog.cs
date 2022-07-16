﻿namespace WildFarm.Models.Animals.Mammal
{
    using System;
    using System.Collections.Generic;
    using Foods;

    public class Dog : Mammal
    {
        private const double DogWeightMultiplier = 0.40;
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {

        }

        protected override IReadOnlyCollection<Type> PrefferedFoods
            => new List<Type> { typeof(Meat)}
            .AsReadOnly();

        protected override double WeightMultiplyer
            => DogWeightMultiplier;

        public override string ProduceSound()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
