
namespace Heroes.Models.Map
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using global::Heroes.Models.Contracts;
    using global::Heroes.Models.Heroes;

    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            var knights = new List<Knight>();
            var barbarians = new List<Barbarian>();

            foreach (var player in players)
            {
                if (player.IsAlive)
                {
                    if (player is Knight knight)
                    {
                        knights.Add(knight);
                    }
                    else if (player is Barbarian barbarian)
                    {
                        barbarians.Add(barbarian);
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid hero type.");
                    }
                }
            }

            bool continueBattle = true;

            while (continueBattle)
            {
                var allKnightAreDead = true;
                var allBarbarianAreDead = true;

                var aliveKnights = 0;
                var aliveBarbarians = 0;

                foreach (var knight in knights)
                {
                    if (knight.IsAlive)
                    {
                        allKnightAreDead = false;
                        aliveKnights++;

                        foreach (var barbarian in barbarians.Where(b => b.IsAlive))
                        {
                            var demage = knight.Weapon.DoDamage();
                            barbarian.TakeDamage(demage);
                        }
                    }
                }

                foreach (var barbarian in barbarians)
                {
                    if (barbarian.IsAlive)
                    {
                        allBarbarianAreDead = false;
                        aliveBarbarians++;

                        foreach (var knight in knights.Where(k => k.IsAlive))
                        {
                            var demage = barbarian.Weapon.DoDamage();
                            knight.TakeDamage(demage);
                        }
                    }
                }

                if (allKnightAreDead)
                {
                    var deathBarberians = barbarians.Count - aliveBarbarians;
                    return $"The barbarians took {deathBarberians} casualties but won the battle.";
                }
                if (allBarbarianAreDead)
                {
                    var deathKnights = knights.Count - aliveKnights;

                    return $"The knights took {deathKnights} casualties but won the battle.";
                }
            }
            throw new InvalidOperationException("The map fight logic has a bug.");
        }
    }
}
