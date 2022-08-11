namespace Formula1.Models
{
    using System;
    using Formula1.Models.Contracts;
    public class Pilot : IPilot
    {
        private string fullName;
        private IFormulaOneCar car;

        public string FullName
        {
            get => this.fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Invalid pilot name: {value}.");
                }
                this.fullName = value;
            }
        }

        public Pilot(string fullName)
        {
            this.FullName = fullName;
            this.CanRace = false;
        }

        public bool CanRace { get; private set; }

        public IFormulaOneCar Car
        {
            get => this.car;
            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Pilot car can not be null.");
                }
                this.car = value;
            }
        }

        public int NumberOfWins { get; private set; }


        public void AddCar(IFormulaOneCar car)
        {
            this.Car = car;
            this.CanRace = true;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }

        public override string ToString()
        {
            return $"Pilot {this.FullName} has {this.NumberOfWins} wins.";
        }
    }
}
