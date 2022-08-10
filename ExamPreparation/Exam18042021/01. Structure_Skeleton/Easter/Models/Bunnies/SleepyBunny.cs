namespace Easter.Models.Bunnies
{
    public class SleepyBunny : Bunny
    {
        private const int InitialEnergy = 50;
        private const int DeffBunnyEnergyDecreaser = 10;
        private const int AdditionaEnergyDecreaser = 5;

        public SleepyBunny(string name)
            : base(name, InitialEnergy)
        {
        }

        public override void Work()
        {
            if (this.Energy < 0)
            {
                this.Energy = 0;
            }
            this.Energy -= (DeffBunnyEnergyDecreaser + AdditionaEnergyDecreaser);
        }
    }
}
