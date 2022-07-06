namespace FootballTeamGenerator
{
    using System;
    public class Player
    {
        private string name;

        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.Stats = stats;
        }

        public string Name 
        { 
            get 
            { 
                return name; 
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

        public Stats Stats { get; private set; }
    }
}
