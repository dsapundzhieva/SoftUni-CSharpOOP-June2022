using TestAxe.Interfaces;

namespace TestAxe.Models
{
    public class Hero
    {
        private string name;
        private int experience;
        private IWeapon weapon;

        public Hero(string name, IWeapon weapon)
        {
            this.Name = name;
            this.Weapon = weapon;
            this.Experience = 0;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Experience
        {
            get { return experience; }
            set { experience = value; }
        }
        public IWeapon Weapon
        {
            get { return weapon; }
            set { weapon = value; }
        }

        public void Attack(ITarget target)
        {
            Weapon.Attack(target);

            if (target.IsDead())
            {
                experience += target.GiveExperience();
            }
        }
    }
}
