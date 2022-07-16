
namespace WildFarm.Models.Animals
{
    using Foods;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Exceptions;

    public abstract class Animal
    {

        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set; }

        protected abstract IReadOnlyCollection<Type> PrefferedFoods { get; }

        protected abstract double WeightMultiplyer { get; }
        public abstract string ProduceSound();

        public void Eat(Food food)
        {
            if (!this.PrefferedFoods.Contains(food.GetType()))
            {
                throw new InvalidTypeOfFood(
                    String.Format(ExceptionMessages.InvalidTypeOfFood, this.GetType().Name, food.GetType().Name));
            }
            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * this.WeightMultiplyer;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
