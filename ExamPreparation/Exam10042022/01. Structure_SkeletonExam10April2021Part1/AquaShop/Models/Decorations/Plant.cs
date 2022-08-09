
namespace AquaShop.Models.Decorations
{
    internal class Plant : Decoration
    {
        private const int DeffComfort = 5;
        private const decimal DeffPrice = 10;
        public Plant()
            : base(DeffComfort, DeffPrice)
        {
        }
    }
}
