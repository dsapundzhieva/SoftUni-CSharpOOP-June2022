
namespace Vehicles.Models
{
    using Vehicles.Models.Interfaces;
    public class Bus : Vehicle
    {
        private const double BussFuelConsumptionIncreaseWithPeople = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        protected override double FuelConsumprionModifier
            => BussFuelConsumptionIncreaseWithPeople;
        //protected override double FuelConsumprionModifier
        //{
        //    get
        //    {
        //        return base.FuelConsumprionModifier;
        //    }
        //    set
        //    {
        //        if (IsEmpty)
        //        {
        //            base.FuelConsumprionModifier = value;
        //        }
        //        else if (!IsEmpty)
        //        {
        //            base.FuelConsumprionModifier = BussFuelConsumptionIncreaseWithPeople;
        //        }
        //    }
        //}
    }
}
