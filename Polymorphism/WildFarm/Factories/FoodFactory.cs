namespace WildFarm.Factories
{
    using Interfaces;
    using Exceptions;
    using Models.Foods;

    public class FoodFactory : IFoodFactory
    {
        public Food CreateFoodFactory(string foodType, int quantity)
        {
            Food food;
            if (foodType == "Vegetable")
            {
                food = new Vegetable(quantity);
            }
            else if (foodType == "Fruit")
            {
                food = new Fruit(quantity);
            }
            else if (foodType == "Meat")
            {
                food = new Meat(quantity);
            }
            else if (foodType == "Seeds")
            {
                food = new Seeds(quantity);
            }
            else
            {
                throw new InvalidFactoryTypeException();
            }

            return food;
        }
    }
}
