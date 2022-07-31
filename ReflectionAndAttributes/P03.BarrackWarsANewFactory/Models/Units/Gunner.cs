
namespace P03.BarrackWarsANewFactory.Models.Units
{
    using _03BarracksFactory.Models.Units;
    internal class Gunner : Unit
    {
        private const int DefaultHealth = 20;
        private const int DefaultDamage = 20;

        public Gunner()
            : base(DefaultHealth, DefaultDamage)
        {
        }
    }
}
