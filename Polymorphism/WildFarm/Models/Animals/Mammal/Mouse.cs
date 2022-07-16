namespace WildFarm.Models.Animals.Mammal
{
    using System;
    using System.Collections.Generic;
    using Foods;

    public class Mouse : Mammal
    {
        private const double MouseWeightMuliplier = 0.10;
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        protected override IReadOnlyCollection<Type> PrefferedFoods
            => new List<Type> { typeof(Vegetable), typeof(Fruit) }
            .AsReadOnly();

        protected override double WeightMultiplyer
            => MouseWeightMuliplier;

        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
