namespace WildFarm.Models.Animals.Mammal
{
    using System;
    using System.Collections.Generic;
    using Foods;

    public class Tiger : Feline
    {
        private const double TigerWeightMultiplier = 1.00;
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {

        }

        protected override IReadOnlyCollection<Type> PrefferedFoods
            => new List<Type> { typeof(Meat) }
            .AsReadOnly();
        protected override double WeightMultiplyer
            => TigerWeightMultiplier;
        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
