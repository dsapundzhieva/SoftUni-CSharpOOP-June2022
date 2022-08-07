using INStock.Contracts;
using System;
using System.Diagnostics.CodeAnalysis;

namespace INStock.Models
{
    public class Product : IProduct
    {
        private string label;
        private decimal price;
        private int quantity;

        public Product(string label, decimal price, int quantity)
        {
            this.Label = label;
            this.Price = price;
            this.Quantity = quantity;
        }

        public string Label
        {
            get { return this.label; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Label name can not be null or whitespace.");
                }
                this.label = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be zero ot negative!");
                }
                this.price = value;
            }
        }

        public int Quantity
        {
            get { return this.quantity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative!");
                }
                this.quantity = value;
            }
        }

        public int CompareTo([AllowNull] IProduct other)
        {
            int result = this.Price.CompareTo(other.Price);

            return result;
        }
    }
}
