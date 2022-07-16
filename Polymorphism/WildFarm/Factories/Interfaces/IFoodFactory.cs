namespace WildFarm.Factories.Interfaces
{
    using Models.Foods;

    public interface IFoodFactory
    {
        Food CreateFoodFactory(string foodType, int quantity);
    }
}
