using Formula1.Models.Contracts;

namespace Formula1.Models
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;
        private ICollection<IPilot> pilots;


        public Race()
        {
            pilots = new List<IPilot>();
            TookPlace = false;
        }

        public Race(string racaName, int numberOfLaps)
            : this()
        {
            RaceName = racaName;
            NumberOfLaps = numberOfLaps;
        }

        public string RaceName
        {
            get => raceName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Invalid race name: {value}.");
                }
                raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get => numberOfLaps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException($"Invalid lap numbers: {value}.");
                }
                numberOfLaps = value;
            }
        }

        public bool TookPlace { get; set; }

        public ICollection<IPilot> Pilots => pilots;

        public void AddPilot(IPilot pilot)
        {
            pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            var result = new StringBuilder();

            result.AppendLine($"The {RaceName} race has:");
            result.AppendLine($"Participants: {Pilots.Count}");
            result.AppendLine($"Number of laps: {NumberOfLaps}");
            result.Append($"Took place: {(TookPlace == true ? "Yes" : "No")}");

            return result.ToString().Trim();
        }
    }
}
