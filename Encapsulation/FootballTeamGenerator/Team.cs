namespace FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Team
    {
        private string name;
        private readonly List<Player> players;

        public Team()
        {
            this.players = new List<Player>();
        }
        public Team(string name)
            : this()
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ErrorMessages.NullOrWhitespaceName);
                }
                this.name = value;
            }
        }

        public IReadOnlyCollection<Player> Players
        {
            get
            {
                return this.players;
            }
        }

        public int Rating
        {
            get
            {
                if (this.players.Any())
                {
                    return (int)Math.Round(this.players.Average(p => p.Stats.GetOverallStat()), 0);
                }
                return 0;
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string name)
        {
            Player player = this.players.FirstOrDefault(p => p.Name == name);
            if (player == null)
            {
                throw new InvalidOperationException(
                String.Format(ErrorMessages.PlayerNotInTeam, name, this.Name));
            }
            this.players.Remove(player);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}

