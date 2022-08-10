namespace Easter.Models.Dyes
{
    using Easter.Models.Dyes.Contracts;
    public class Dye : IDye
    {
        private const int DeffDyePowerDecreaser = 10;
        private int power;

        public Dye(int power)
        {
            this.Power = power;
        }

        public int Power
        {
            get => this.power;
            private set
            {
                if (value < 0)
                {
                    this.power = 0;
                }
                this.power = value;
            }
        }
        public void Use()
        {
            if (this.Power < 0)
            {
                this.Power = 0;
            }
            this.Power -= DeffDyePowerDecreaser;
        }
        public bool IsFinished() => this.Power == 0;
    }
}
