namespace Raiding.Exceptions
{
    using System;
    public class InvalidHeroType : Exception
    {
        private const string InvalidHero = "Invalid hero!";
        public InvalidHeroType()
            : base(InvalidHero)
        {

        }
    }
}
