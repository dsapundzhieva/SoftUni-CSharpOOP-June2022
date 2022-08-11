
namespace CarRacing.Models.Racers
{
    using CarRacing.Models.Cars.Contracts;
    public class StreetRacer : Racer
    {
        private const int DefaultDrivingExpirience = 10;
        private const string DefaultRacingBehavior = "aggressive";
        private const int DefaultDrivingExpirienceIncreaser = 5;


        public StreetRacer(string username, ICar car)
            : base(username, DefaultRacingBehavior, DefaultDrivingExpirience, car)
        {
        }

        public override void Race()
        {
            base.Race();
            this.DrivingExperience += DefaultDrivingExpirienceIncreaser;
        }
    }
}
