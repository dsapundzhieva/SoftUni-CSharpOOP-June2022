namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {
        private const int increaseFishSize = 3;
        public FreshwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
            this.Size = 3;
        }

        public override void Eat()
        {
            this.Size += increaseFishSize;
        }
    }
}
