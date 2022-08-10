namespace Easter.Models.Bunnies
{
    public class HappyBunny : Bunny
    {
        private const int InitialEnergy = 100;
        private const int DeffBunnyEnergyDecreaser = 10;

        public HappyBunny(string name) 
            : base(name, InitialEnergy)
        {
        }

        public override void Work()
        {
            if (this.Energy < 0)
            {
                this.Energy = 0;
            }
            this.Energy -= DeffBunnyEnergyDecreaser;
        }
    }
}
