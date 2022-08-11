namespace CarRacing.Models.Maps
{
    using CarRacing.Models.Maps.Contracts;
    using CarRacing.Models.Racers.Contracts;
    using System;
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return "Race cannot be completed because both racers are not available!";
            }
            else if (!racerOne.IsAvailable())
            {
                return $"{racerTwo.Username} wins the race! {racerOne.Username} was not available to race!";
            }
            else if (!racerTwo.IsAvailable())
            {
                return $"{racerOne.Username} wins the race! {racerTwo.Username} was not available to race!";
            }
            else
            {
                racerOne.Race();
                racerTwo.Race();


                var takeRacerOneBehaviorMultiplier = racerOne.RacingBehavior == "strict" ? 1.2 : 1.1;
                var takeRacerTwoBehaviorMultiplier = racerTwo.RacingBehavior == "strict" ? 1.2 : 1.1;

                var chanceOfWinningRacerOne = racerOne.Car.HorsePower * racerOne.DrivingExperience * takeRacerOneBehaviorMultiplier;
                var chanceOfWinningRacerTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * takeRacerTwoBehaviorMultiplier;

                if (chanceOfWinningRacerOne > chanceOfWinningRacerTwo)
                {
                    return $"{racerOne.Username} has just raced against {racerTwo.Username}! {racerOne.Username} is the winner!";
                }
                else
                {
                    return $"{racerOne.Username} has just raced against {racerTwo.Username}! {racerTwo.Username} is the winner!";
                }
            }
        }
    }
}
