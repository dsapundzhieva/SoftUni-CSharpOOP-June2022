using INStock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INStock.Models
{
    public class ProductStock : IProductStock
    {
        private readonly ICollection<IProduct> products;

        public ProductStock(ICollection<IProduct> products)
        {
            this.products = products;
        }

        public IReadOnlyCollection<IProduct> Products { get => (IReadOnlyCollection<IProduct>)this.products; }

        public IProduct this[int index]
        {
            get => (Product)this.products.ToList()[index];
            set
            {
                if (index < 0)
                {
                    throw new IndexOutOfRangeException("Index in under zero");
                }
                if (index > this.products.Count)
                {
                    throw new IndexOutOfRangeException("Index is above the collection size.");
                }
                this.products.ToList()[index] = value;
            }
        }

        public int Count => this.products.Count;

       
        public void Add(IProduct product)
        {
            if (this.products.Any(p => p.Label == product.Label))
            {
                throw new InvalidOperationException($"Product with label {product.Label} already exists!");
            }

            this.products.Add(product);
        }

        public bool Contains(IProduct product)
        {
            return this.products.Any(p => p.Label == product.Label);
        }

        public IProduct Find(int index)
        {
            if (index < 0 || index >= this.products.Count)
            {
                throw new IndexOutOfRangeException("Index was outside the bounds of the array");
            }
            return this.products.ToList()[index];
        }

        public IEnumerable<IProduct> FindAllByPrice(decimal price)
        {
            return this.products.Where(p => p.Price == price).ToList();
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            return this.products.Where(p => p.Quantity == quantity).ToList();
        }

        public IEnumerable<IProduct> FindAllInRange(decimal lo, decimal hi)
        {
            return this.products.Where(p => p.Price >= lo && p.Price <= hi).OrderByDescending(p => p.Price).ToList();
        }

        public IProduct FindByLabel(string label)
        {
            var searchProductByLabel = this.products.FirstOrDefault(p => p.Label == label);
            if (searchProductByLabel == null)
            {
                throw new ArgumentException("The serching product does not exist!");
            }
            return searchProductByLabel;
        }

        public ICollection<IProduct> FindMostExpensiveProduct(int count)
        {
            return this.products.OrderByDescending(p => p.Price).Take(count).ToList();
        }

        public bool Remove(IProduct product)
        {
            if (this.products.Contains(product))
            {
                this.products.Remove(product);
                return true;
            }
            return false;
        }

        public IEnumerator<IProduct> GetEnumerator() => this.products.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
