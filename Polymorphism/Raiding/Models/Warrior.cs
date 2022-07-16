namespace Raiding.Models
{
    internal class Warrior : BaseHero
    {
        private const int DefaultPower = 100;

        public Warrior(string name, string type)
            : base(name, type)
        {
        }

        public override int Power
        {
            get
            {
                return DefaultPower;
            }
            set
            {
                base.Power = DefaultPower;
            }
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
