
namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Pizza
    {
        private const int minLengthName = 1;
        private const int maxLengthName = 15;

        private string name;
        private readonly List<Topping> toppings;

        public Pizza()
        {
            this.toppings = new List<Topping>();
        }

        public Pizza(string name, Dough dough)
            : this()
        {
            this.Name = name;
            this.Dough = dough;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < minLengthName || value.Length > maxLengthName)
                {
                    throw new ArgumentException(ErrorMessages.NullOrWhitespaceName);
                }
                this.name = value;
            }

        }

        public Dough Dough { get; set; }

        public IReadOnlyCollection<Topping> Toppings => this.toppings;

        public double TotalCalories 
        { 
            get 
            {
                return this.Dough.CalculateDoughCaloriesPerGram() + toppings.Sum(s => s.CalculateToppingCaloriesPerGram());
            }
        }

        public void AddTopping(Topping topping)
        {
            if (this.Toppings.Count > 10)
            {
                throw new ArgumentException(ErrorMessages.ToppingInvalidValue);
            }
            this.toppings.Add(topping);
        }
    }
}
