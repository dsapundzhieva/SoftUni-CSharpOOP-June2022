namespace WildFarm.Models.Animals.Mammal
{
    using System;
    using System.Collections.Generic;
    using Foods;

    public class Cat : Feline
    {
        private const double CatWeightMultiplier = 0.30;
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {

        }

        protected override IReadOnlyCollection<Type> PrefferedFoods
            => new List<Type> { typeof(Meat), typeof(Vegetable) }
            .AsReadOnly();

        protected override double WeightMultiplyer
            => CatWeightMultiplier;
        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
