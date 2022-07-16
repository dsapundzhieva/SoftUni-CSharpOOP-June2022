namespace WildFarm.Models.Animals.Birds
{
    using System;
    using System.Collections.Generic;
    using Foods;

    public class Owl : Bird
    {
        private const double OwlWeightMuliplier = 0.25;
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {

        }

        protected override IReadOnlyCollection<Type> PrefferedFoods 
            => new List<Type> {typeof(Meat) }
            .AsReadOnly();

        protected override double WeightMultiplyer
            => OwlWeightMuliplier;

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
