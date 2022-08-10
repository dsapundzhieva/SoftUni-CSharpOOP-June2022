
namespace Easter.Models.Workshops
{
    using Easter.Models.Bunnies.Contracts;
    using Easter.Models.Eggs.Contracts;
    using Easter.Models.Workshops.Contracts;
    using System.Linq;

    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            foreach (var dye in bunny.Dyes)
            {
                while (bunny.Energy > 0 && !dye.IsFinished())
                {
                    if (egg.IsDone())
                    {
                        return;
                    }
                    else
                    {
                        bunny.Work();
                        dye.Use();
                        egg.GetColored();
                    }
                }
            }
        }
    }
}
