
namespace CarRacing.Core.Contracts
{
    using System;
    using System.Text;
    using System.Linq;
    using CarRacing.Models.Cars;
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Models.Maps;
    using CarRacing.Models.Maps.Contracts;
    using CarRacing.Models.Racers;
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Repositories;
    using CarRacing.Repositories.Contracts;

    public class Controller : IController
    {
        private readonly IRepository<ICar> cars;
        private readonly IRepository<IRacer> raceres;
        private readonly IMap map;

        public Controller()
        {
            this.cars = new CarRepository();
            this.raceres = new RacerRepository();
            this.map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car = type switch
            {
                nameof(SuperCar) => new SuperCar(make, model, VIN, horsePower),
                nameof(TunedCar) => new TunedCar(make, model, VIN, horsePower),
                _ => throw new ArgumentException("Invalid car type!")
            };
            this.cars.Add(car);

            return $"Successfully added car {make} {model} ({VIN}).";
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            var carToAdd = this.cars.FindBy(carVIN);

            if (carToAdd == null)
            {
                throw new ArgumentException("Car cannot be found!");
            }

            IRacer racer = type switch
            {
                nameof(ProfessionalRacer) => new ProfessionalRacer(username, carToAdd),
                nameof(StreetRacer) => new StreetRacer(username, carToAdd),
                _ => throw new ArgumentException("Invalid racer type!")
            };

            this.raceres.Add(racer);
            return $"Successfully added racer {username}.";
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            var racerOne = this.raceres.FindBy(racerOneUsername);
            var racerTwo = this.raceres.FindBy(racerTwoUsername);

            if (racerOne == null)
            {
                throw new ArgumentException($"Racer {racerOneUsername} cannot be found!");
            }
            if (racerTwo == null)
            {
                throw new ArgumentException($"Racer {racerTwoUsername} cannot be found!");
            }

            var result = this.map.StartRace(racerOne, racerTwo);
            return result;
        }

        public string Report()
        {
            var result = new StringBuilder();

            var orderedRacers = this.raceres
                .Models
                .OrderByDescending(r => r.DrivingExperience)
                .ThenBy(r => r.Username)
                .ToList();

            foreach (var racer in orderedRacers)
            {
                result.AppendLine(racer.ToString());
            }

            return result.ToString().Trim();
        }
    }
}
