namespace WildFarm.Factories.Interfaces
{
    using Models.Animals;

    public interface IAnimalFactory
    {
        Animal CreateAnimalFactory(string type, string name, double weight, string thirdParam, string fourthParam = null);
    }
}
