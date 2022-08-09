namespace AquaShop.Models.Aquariums
{
    public class FreshwaterAquarium : Aquarium
    {
        private const int DeffCapacity = 50;
        public FreshwaterAquarium(string name) 
            : base(name, DeffCapacity)
        {
        }
    }
}
