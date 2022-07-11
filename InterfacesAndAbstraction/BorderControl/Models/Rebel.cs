using BorderControl.Contracts;

namespace BorderControl.Models
{
    public class Rebel : IBuyer
    {
        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Group = group;
            this.Food = 0;
        }

        public string Name { get; private set; }

        public string Group { get; set; }
        public int Food { get ; set ; }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
