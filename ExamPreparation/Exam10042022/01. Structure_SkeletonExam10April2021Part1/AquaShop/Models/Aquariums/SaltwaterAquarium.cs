namespace AquaShop.Models.Aquariums
{
    public class SaltwaterAquarium : Aquarium
    {
        private const int DeffCapacity = 25;

        public SaltwaterAquarium(string name) 
            : base(name, DeffCapacity)
        {
        }
    }
}
