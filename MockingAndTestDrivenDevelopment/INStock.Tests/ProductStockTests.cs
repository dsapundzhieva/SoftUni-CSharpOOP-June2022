namespace INStock.Tests
{
    using INStock.Contracts;
    using INStock.Models;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductStockTests
    {

        private ProductStock productStock;

        [SetUp]
        public void SetUp()
        {
            this.productStock = new ProductStock(new List<IProduct>());
        }

        [Test]
        public void ConstructorShouldInitializedProperly()
        {
            Assert.IsNotNull(productStock);
        }

        [Test]
        public void AddProductInProductStockSuccessfullly()
        {
            Product product = new Product("Product1", 44, 7);
            this.productStock.Add(product);

            int expectedCount = 1;
            int actualCount = this.productStock.Count;

            var expectedCollection = new List<Product>() { product };
            var actualCollection = productStock;

            Assert.AreEqual(expectedCount, actualCount);
            CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }

        [Test]
        public void AddExistingProductInProductStockShouldThrowException()
        {
            Product product = new Product("Product1", 44, 7);
            this.productStock.Add(product);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.productStock.Add(product);
            }, $"Product with label {product.Label} already exists!");
        }

        [Test]
        public void TestIfProductStockContainsProduct()
        {
            Product product = new Product("Product1", 44, 7);
            this.productStock.Add(product);

            var searchedProduct = productStock.Contains(product);

            Assert.IsTrue(searchedProduct);
        }

        [Test]
        public void TestIfProductStockDoesNotContainProduct()
        {
            Product product1 = new Product("Product1", 44, 7);
            Product product2 = new Product("Product2", 44, 7);

            this.productStock.Add(product1);

            var searchedProduct = productStock.Contains(product2);

            Assert.IsFalse(searchedProduct);
        }

        [Test]
        public void FindExistingProductIndexInProductStock()
        {
            Product product = new Product("Product1", 44, 7);
            this.productStock.Add(product);

            var searchedProduct = productStock.Find(0);

            Assert.AreEqual(product, searchedProduct);
        }

        [TestCase(-1)]
        [TestCase(2)]
        [TestCase(10)]
        public void FindNonExistingProductIndexInProductStockShouldThrowException(int index)
        {
            Product product = new Product("Product1", 44, 7);
            this.productStock.Add(product);


            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                var searchedProduct = productStock.Find(index);
            }, "Index was outside the bounds of the array");
        }

        [TestCase(4)]
        public void FindAllProductsByPriceSuccessfully(decimal price)
        {
            Product product1 = new Product("Product1", 4, 7);
            Product product2 = new Product("Product2", 4, 7);
            Product product3 = new Product("Product3", 5, 7);

            this.productStock.Add(product1);
            this.productStock.Add(product2);
            this.productStock.Add(product3);

            ICollection<IProduct> expectedProducts = new List<IProduct>();
            expectedProducts.Add(product1);
            expectedProducts.Add(product2);

            var actualCollection = productStock.FindAllByPrice(price);

            CollectionAssert.AreEqual(expectedProducts, actualCollection);
        }

        [TestCase(7)]
        public void FindAllProductsByQuantitySuccessfully(int quantity)
        {
            Product product1 = new Product("Product1", 4, 7);
            Product product2 = new Product("Product2", 4, 7);
            Product product3 = new Product("Product3", 5, 3);

            this.productStock.Add(product1);
            this.productStock.Add(product2);
            this.productStock.Add(product3);

            ICollection<IProduct> expectedProducts = new List<IProduct>();
            expectedProducts.Add(product1);
            expectedProducts.Add(product2);

            var actualCollection = productStock.FindAllByQuantity(quantity);

            CollectionAssert.AreEqual(expectedProducts, actualCollection);
        }


        [TestCase(4,7)]
        public void FindAllProductsInRangeSuccessfully(decimal lo, decimal hi)
        {
            Product product1 = new Product("Product1", 4, 7);
            Product product2 = new Product("Product2", 7, 7);
            Product product3 = new Product("Product3", 5, 3);
            Product product4 = new Product("Product4", 9, 3);


            this.productStock.Add(product1);
            this.productStock.Add(product2);
            this.productStock.Add(product3);
            this.productStock.Add(product4);

            ICollection<IProduct> expectedProducts = new List<IProduct>();
            expectedProducts.Add(product1);
            expectedProducts.Add(product2);
            expectedProducts.Add(product3);
            expectedProducts = expectedProducts.OrderByDescending(p => p.Price).ToList();

            var actualCollection = productStock.FindAllInRange(lo, hi);

            CollectionAssert.AreEqual(expectedProducts, actualCollection);
        }

        [Test]
        public void FindProductByLabelSuccessfully()
        {
            Product product1 = new Product("Product1", 4, 7);
            Product product2 = new Product("Product2", 4, 7);
            Product product3 = new Product("Product3", 5, 3);

            this.productStock.Add(product1);
            this.productStock.Add(product2);
            this.productStock.Add(product3);

            var actualLabel = productStock.FindByLabel("Product1");

            Assert.AreEqual(product1.Label, actualLabel.Label);
        }

        [Test]
        public void FindNonExistingProductByLabelShouldThrowException()
        {
            Product product1 = new Product("Product1", 4, 7);
            Product product2 = new Product("Product2", 4, 7);
            Product product3 = new Product("Product3", 5, 3);

            this.productStock.Add(product1);
            this.productStock.Add(product2);
            this.productStock.Add(product3);

            Assert.Throws<ArgumentException>(() =>
            {
                var actualLabel = productStock.FindByLabel("Product8");
            }, "The serching product does not exist!");
        }

        [TestCase(2)]
        [TestCase(3)]
        [TestCase(1)]
        [TestCase(4)]
        [TestCase(5)]
        public void FindMostExpensiveProductSuccessfully(int count)
        {
            Product product1 = new Product("Product1", 44, 7);
            Product product2 = new Product("Product2", 90, 7);
            Product product3 = new Product("Product3", 55, 3);
            Product product4 = new Product("Product4", 51, 3);
            Product product5 = new Product("Product5", 53, 3);


            this.productStock.Add(product1);
            this.productStock.Add(product2);
            this.productStock.Add(product3);
            this.productStock.Add(product4);
            this.productStock.Add(product5);


            var actualCollectionCount = productStock.FindMostExpensiveProduct(count).Count;

            Assert.AreEqual(count, actualCollectionCount);
        }

        [Test]
        public void RemoveProductSuccessfully()
        {
            Product product1 = new Product("Product1", 44, 7);
            Product product2 = new Product("Product2", 90, 7);
            Product product3 = new Product("Product3", 55, 3);
            Product product4 = new Product("Product4", 51, 3);
            Product product5 = new Product("Product5", 53, 3);

            this.productStock.Add(product1);
            this.productStock.Add(product2);
            this.productStock.Add(product3);
            this.productStock.Add(product4);
            this.productStock.Add(product5);

            var isRemoved = productStock.Remove(product4);

            Assert.That(isRemoved, Is.True);
        }

        [Test]
        public void RemoveNonExistingProductShouldThrowException()
        {
            Product product1 = new Product("Product1", 44, 7);
            Product product2 = new Product("Product2", 90, 7);
            Product product3 = new Product("Product3", 55, 3);
            Product product4 = new Product("Product4", 51, 3);
            Product product5 = new Product("Product5", 53, 3);

            this.productStock.Add(product1);
            this.productStock.Add(product2);
            this.productStock.Add(product3);
            this.productStock.Add(product4);

            var isRemoved = productStock.Remove(product5);

            Assert.That(isRemoved, Is.False);
        }

        [Test]
        public void ProductStockIndexShouldWorkCorrectly()
        {
            Product product1 = new Product("Product1", 44, 7);
            Product product2 = new Product("Product2", 90, 7);
            Product product3 = new Product("Product3", 55, 3);
          

            this.productStock.Add(product1);
            this.productStock.Add(product2);
            this.productStock.Add(product3);

            Product expectedProduct = product1;
            Product actualProduct = (Product)this.productStock[0];

            Assert.AreEqual(expectedProduct, actualProduct);
        }

        //[Test]
        //public void TestSetterProductStockIndexShouldWorkCorrectly()
        //{
        //    Product product1 = new Product("Product1", 44, 7);
        //    Product product2 = new Product("Product2", 90, 7);
        //    Product product3 = new Product("Product3", 55, 3);
        //    Product product4 = new Product("Product4", 66, 73);


        //    this.productStock.Add(product1);
        //    this.productStock.Add(product2);
        //    this.productStock.Add(product3);
        //    this.productStock.Add(product4);


        //    this.productStock[3] = new Product("new", 69, 9);
        //    var result = this.productStock.Find(3);

        //    Assert.Multiple(() =>
        //    {
        //        Assert.That(result, Is.Not.Null);
        //        Assert.That(result.Label, Is.EqualTo("new"));
        //        Assert.That(result.Price, Is.EqualTo(69));
        //        Assert.That(result.Quantity, Is.EqualTo(9));
        //    });
        //}

    }
}
