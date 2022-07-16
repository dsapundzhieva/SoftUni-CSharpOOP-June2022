
namespace Raiding.Factories
{
    using Interfaces;
    using Exceptions;
    using Models;

    public class FactoryHero : IFactoryHero
    {
        public BaseHero CreateHero(string name, string type)
        {
            BaseHero baseHero;

            if (type == "Druid")
            {
                baseHero = new Druid(name, type);
            }
            else if (type == "Paladin")
            {
                baseHero = new Paladin(name, type);
            }
            else if (type == "Rogue")
            {
                baseHero = new Rogue(name, type);
            }
            else if (type == "Warrior")
            {
                baseHero = new Warrior(name, type);
            }
            else
            {
                throw new InvalidHeroType();
            }

            return baseHero;
        }
    }
}
