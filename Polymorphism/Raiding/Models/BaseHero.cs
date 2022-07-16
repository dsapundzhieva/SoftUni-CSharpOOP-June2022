namespace Raiding.Models
{
    public abstract class BaseHero
    {
        private string name;
        private int power;
        protected BaseHero(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }

        public string Name 
        {
            get
            {
                return this.name;
            } 
            protected set
            {
                this.name = value;
            } 
        }

        public virtual int Power 
        {
            get
            {
                return this.power;
            }
            set
            {
                this.power = value;
            }
        }

        public string Type { get; protected set; }

        public abstract string CastAbility();

    }
}
