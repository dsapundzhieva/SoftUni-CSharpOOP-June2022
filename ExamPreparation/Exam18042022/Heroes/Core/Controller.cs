namespace Heroes.Core
{
    using Heroes.Core.Contracts;
    using Heroes.Models.Contracts;
    using Heroes.Models.Heroes;
    using Heroes.Models.Map;
    using Heroes.Models.Weapons;
    using Heroes.Repositories;
    using Heroes.Repositories.Contracts;
    using System;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private readonly IRepository<IHero> heroes;
        private readonly IRepository<IWeapon> weapons;

        public Controller()
        {
            this.heroes = new HeroRepository();
            this.weapons = new WeaponRepository();
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            if (this.heroes.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }

            IHero hero = type switch
            {
                nameof(Knight) => new Knight(name, health, armour),
                nameof(Barbarian) => new Barbarian(name, health, armour),
                _ => throw new InvalidCastException("Invalid hero type.")
            };

            this.heroes.Add(hero);

            var heroAlias = type == nameof(Knight)
                ? $"Sir {hero.Name}"
                : $"{nameof(Barbarian)} {hero.Name}";

            return $"Successfully added {heroAlias} to the collection.";

        }

        public string CreateWeapon(string type, string name, int durability)
        {
            if (this.weapons.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");
            }

            IWeapon weapon = type switch
            {
                nameof(Mace) => new Mace(name, durability),
                nameof(Claymore) => new Claymore(name, durability),
                _=> throw new InvalidOperationException("Invalid weapon type.")
            };

            this.weapons.Add(weapon);

            return $"A {type.ToLower()} {name} is added to the collection.";
        }


        public string AddWeaponToHero(string weaponName, string heroName)
        {
            var hero = this.heroes.FindByName(heroName);
            var weaponToAdd = this.weapons.FindByName(weaponName);

            if (hero == null)
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }
            if (weaponToAdd == null)
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }

            if (hero.Weapon != null)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }

            hero.AddWeapon(weaponToAdd);

            this.weapons.Remove(weaponToAdd);

            var weaponType = weaponToAdd.GetType().Name.ToLower();

            return $"Hero {heroName} can participate in battle using a {weaponType}.";
        }        

        public string StartBattle()
        {
            var map = new Map();

            var heroReadyForBattle = this.heroes
                .Models
                .Where(h => h.IsAlive && h.Weapon != null)
                .ToList();

            return map.Fight(heroReadyForBattle);
        }

        public string HeroReport()
        {
            var result = new StringBuilder();

            var sortedHeroes = this.heroes
                .Models
                .OrderBy(h => h.GetType().Name)
                .ThenByDescending(h => h.Health)
                .ThenBy(h => h.Name);

            foreach (var hero in sortedHeroes)
            {
                result.AppendLine(hero.ToString());
            }
            return result.ToString().Trim();
        }
    }
}
