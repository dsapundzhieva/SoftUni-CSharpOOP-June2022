
namespace WildFarm.Models.Animals.Birds
{
    using System;
    using System.Collections.Generic;
    using Foods;

    public class Hen : Bird
    {
        private const double HenWeightMultiplier = 0.35;
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {

        }

        protected override IReadOnlyCollection<Type> PrefferedFoods
            => new List<Type>
            { typeof(Fruit), typeof(Vegetable), typeof(Meat), typeof(Seeds)}
            .AsReadOnly();

        protected override double WeightMultiplyer
            => HenWeightMultiplier;

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
