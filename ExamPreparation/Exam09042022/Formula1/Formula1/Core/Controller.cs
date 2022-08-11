
namespace Formula1.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using Formula1.Core.Contracts;
    using Formula1.Models;
    using Formula1.Models.Contracts;
    using Formula1.Repositories;
    using Formula1.Repositories.Contracts;

    public class Controller : IController
    {
        private IRepository<IPilot> pilotRepository;
        private IRepository<IRace> raceRepository;
        private IRepository<IFormulaOneCar> carRepository;

        public Controller()
        {
            this.pilotRepository = new PilotRepository();
            this.raceRepository = new RaceRepository();
            this.carRepository = new FormulaOneCarRepository();
        }

        public string CreatePilot(string fullName)
        {
            var pilot = this.pilotRepository.FindByName(fullName);

            if (pilot != null)
            {
                throw new InvalidOperationException($"Pilot {fullName} is already created.");
            }

            this.pilotRepository.Add(new Pilot(fullName));

            return $"Pilot {fullName} is created.";
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            var car = this.carRepository.FindByName(model);

            if (car != null)
            {
                throw new InvalidOperationException($"Formula one car {model} is already created.");
            }

            IFormulaOneCar typeOfCar = type switch
            {
                nameof(Ferrari) => new Ferrari(model, horsepower, engineDisplacement),
                nameof(Williams) => new Williams(model, horsepower, engineDisplacement),
                _=> throw new InvalidOperationException($"Formula one car type {type} is not valid.")
            };

            this.carRepository.Add(typeOfCar);

            return $"Car {type}, model {model} is created.";
        }


        public string CreateRace(string raceName, int numberOfLaps)
        {
            var race = this.raceRepository.FindByName(raceName);

            if (race != null)
            {
                throw new InvalidOperationException($"Race {raceName} is already created.");
            }

            this.raceRepository.Add(new Race(raceName, numberOfLaps));
            return $"Race {raceName} is created.";
        }


        public string AddCarToPilot(string pilotName, string carModel)
        {
            var pilot = this.pilotRepository.FindByName(pilotName);
            var car = this.carRepository.FindByName(carModel);

            if (pilot == null || pilot.Car != null)
            {
                throw new InvalidOperationException($"Pilot {pilotName} does not exist or has a car.");
            }

            if (car == null)
            {
                throw new NullReferenceException($"Car {carModel} does not exist.");
            }

            pilot.AddCar(car);
            this.carRepository.Remove(car);
            return $"Pilot {pilotName} will drive a {car.GetType().Name} {carModel} car.";
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            var race = this.raceRepository.FindByName(raceName);
            var pilot = this.pilotRepository.FindByName(pilotFullName);

            if (race == null)
            {
                throw new NullReferenceException($"Race {raceName} does not exist.");
            }

            if (pilot == null || !pilot.CanRace || race.Pilots.Any(p => p.FullName == pilotFullName))
            {
                throw new InvalidOperationException($"Can not add pilot {pilotFullName} to the race.");
            }

            race.AddPilot(pilot);

            return $"Pilot {pilotFullName} is added to the {raceName} race.";
        }

        public string StartRace(string raceName)
        {
            var race = this.raceRepository.FindByName(raceName);
            
            if (race == null)
            {
                throw new NullReferenceException($"Race {raceName} does not exist.");
            }
            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than three participants.");
            }
            if (race.TookPlace)
            {
                throw new InvalidOperationException($"Can not execute race {raceName}.");
            }

            int laps = race.NumberOfLaps;

            var sortedPilots = race.Pilots.OrderByDescending(p => p.Car.RaceScoreCalculator(laps)).Take(3).ToList();

            race.TookPlace = true;

            var winner = sortedPilots.First();
            winner.WinRace();

            var result = new StringBuilder();

            result.AppendLine($"Pilot {winner.FullName} wins the {race.RaceName} race.");
            result.AppendLine($"Pilot {sortedPilots[1].FullName} is second in the {raceName} race.");
            result.AppendLine($"Pilot {sortedPilots[2].FullName} is third in the {raceName} race.");

            return result.ToString().Trim();
        }

        public string RaceReport()
        {
            var result = new StringBuilder();

            var executedRace = this.raceRepository.Models.Where(r => r.TookPlace).ToList();

            foreach (var race in executedRace)
            {
                result.AppendLine(race.RaceInfo());
            }

            return result.ToString().Trim();
        }

        public string PilotReport()
        {
            var result = new StringBuilder();

            var orderedPilots = this.pilotRepository.Models.OrderByDescending(p => p.NumberOfWins).ToList();

            foreach (var pilot in orderedPilots)
            {
                result.AppendLine(pilot.ToString());
            }

            return result.ToString().Trim();
        }
    }
}
