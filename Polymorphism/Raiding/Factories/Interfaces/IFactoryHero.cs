
namespace Raiding.Factories.Interfaces
{
    using Models;
    public interface IFactoryHero
    {
        BaseHero CreateHero(string name, string type);
    }
}
