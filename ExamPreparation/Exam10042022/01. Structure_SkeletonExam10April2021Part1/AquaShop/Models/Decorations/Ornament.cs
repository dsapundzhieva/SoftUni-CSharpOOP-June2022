
namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        private const int DeffComfort = 1;
        private const decimal DeffPrice = 5;

        public Ornament() 
            : base(DeffComfort, DeffPrice)
        {
        }
    }
}
