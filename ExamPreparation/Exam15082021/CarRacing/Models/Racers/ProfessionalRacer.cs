
namespace CarRacing.Models.Racers
{
    using CarRacing.Models.Cars.Contracts;
    public class ProfessionalRacer : Racer
    {
        private const int DefaultDrivingExpirience = 30;
        private const string DefaultRacingBehavior = "strict";
        private const int DefaultDrivingExpirienceIncreaser = 10;


        public ProfessionalRacer(string username, ICar car)
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
