namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int DefaultPower = 80;
        public Druid(string name, string type) 
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
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
