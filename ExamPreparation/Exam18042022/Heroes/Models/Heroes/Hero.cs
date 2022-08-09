
namespace Heroes.Models.Heroes
{
    using System;
    using System.Text;
    using global::Heroes.Models.Contracts;

    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;

        protected Hero(string name, int health, int armour)
        {
            this.Name = name;
            this.Health = health;
            this.Armour = armour;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }
                this.name = value;
            }
        }
        public int Health
        {
            get { return this.health; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }
                this.health = value;
            }
        }
        public int Armour
        {
            get { return this.armour; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }
                this.armour = value;
            }
        }

        public bool IsAlive => this.Health > 0;

        public IWeapon Weapon
        {
            get { return this.weapon; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Weapon cannot be null.");
                }
                this.weapon = value;
            }
        }

        public void AddWeapon(IWeapon weapon) => this.Weapon = weapon;

        public void TakeDamage(int points)
        {
            int armourLeft = this.Armour - points;

            if (armourLeft >= 0)
            {
                this.Armour = armourLeft;
            }
            else
            {
                this.Armour = 0;

                var damage = -armourLeft;

                int healthLeft = this.Health - damage;

                if (healthLeft < 0)
                {
                    this.Health = 0;
                }
                else
                {
                    this.Health = healthLeft;
                }
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"{this.GetType().Name}: {this.Name}");
            result.AppendLine($"--Health: {this.Health}");
            result.AppendLine($"--Armour: {this.Armour}");
            result.Append($"--Weapon: {(this.Weapon == null ? "Unarmed" : this.Weapon.Name)}");

            return result.ToString().TrimEnd();
        }
    }
}
