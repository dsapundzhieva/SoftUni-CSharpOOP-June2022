namespace INStock
{
    using INStock.Contracts;
    using INStock.Models;
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                var product1 = new Product("testProduct1", 3.4m, 5);
                var product2 = new Product("testProduct2", 3.25m, 54);
                var product3 = new Product("testProduct3", 35.3m, 1);
                ICollection<IProduct> products = new List<IProduct>();

                var productStock = new ProductStock(products);

                productStock.Add(product1);
                productStock.Add(product2);
                productStock.Add(product3);

                products.Contains(product3);

                products.Remove(product3);

                foreach (var item in products)
                {
                    Console.WriteLine(item.Label);
                }

                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
