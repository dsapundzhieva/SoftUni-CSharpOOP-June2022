
namespace PizzaCalories
{
    using System;
    public class Dough
    {
        private const double BaseCkalPerGram = 2.0;

        private const double CkalWhiteDoughPerGram = 1.5;
        private const double CkalWholegrainDoughPerGram = 1.0;

        private const double CkalCrispyTechniquePerGram = 0.9;
        private const double CkalChewyTechniquePerGram = 1.1;
        private const double CkalHomemadeTechniquePerGram = 1.0;

        private const string WhiteDough = "white";
        private const string WholegrainDough = "wholegrain";
        private const string CrispyDough = "crispy";
        private const string ChewyDough = "chewy";
        private const string HommemadeDough = "homemade";

        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;
            private set
            {
                if (value.ToLower() != WhiteDough && value.ToLower() != WholegrainDough)
                {
                    throw new ArgumentException(ErrorMessages.DoughInavlidValue);
                }
                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set
            {
                if (value.ToLower() != CrispyDough && value.ToLower() != ChewyDough && value.ToLower() != HommemadeDough)
                {
                    throw new ArgumentException(ErrorMessages.DoughInavlidValue);
                }
                this.bakingTechnique = value;
            }
        }

        public int Weight
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException(ErrorMessages.DoughInavlidWeight);
                }
                this.weight = value;
            }
        }

        public double CalculateDoughCaloriesPerGram()
        {
            double calories = this.weight * BaseCkalPerGram;

            if (this.bakingTechnique.ToLower() == ChewyDough)
            {
                calories *= CkalChewyTechniquePerGram;
            }
            else if (this.bakingTechnique.ToLower() == CrispyDough)
            {
                calories *= CkalCrispyTechniquePerGram;
            }
            else if (this.bakingTechnique.ToLower() == HommemadeDough)
            {
                calories *= CkalHomemadeTechniquePerGram;
            }

            if (this.flourType.ToLower() == WhiteDough)
            {
                calories *= CkalWhiteDoughPerGram;
            }
            else if (this.flourType.ToLower() == WholegrainDough)
            {
                calories *= CkalWholegrainDoughPerGram;
            }
            return calories;
        }
    }
}
