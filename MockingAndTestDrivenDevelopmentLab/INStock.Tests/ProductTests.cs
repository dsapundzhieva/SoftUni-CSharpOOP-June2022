namespace INStock.Tests
{
    using INStock.Models;
    using NUnit.Framework;
    using System;

    public class ProductTests
    {
        [Test]
        public void ConstructorShouldInitializeValuesProperly()
        {
            string expectedLabel = "product1";
            decimal expectedPrice = 77;
            int expectedQuantity = 7;

            var product = new Product(expectedLabel, expectedPrice, expectedQuantity);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedLabel, product.Label);
                Assert.AreEqual(expectedPrice, product.Price);
                Assert.AreEqual(expectedQuantity, product.Quantity);
            }
            );
        }

        [TestCase("")]
        [TestCase("           ")]
        [TestCase(null)]
        public void TestSetterLabel(string label)
        {

            Assert.Throws<ArgumentException>(() =>
            {
                var product = new Product(label, 33, 2);
            }, "Label name can not be null or whitespace.");


        }


        [TestCase(-3)]
        [TestCase(-1)]
        public void TestSetterPrice(decimal price)
        {

            Assert.Throws<ArgumentException>(() =>
            {
                var product = new Product("Product1", price, 2);
            }, "Price cannot be zero ot negative!");
        }

        [TestCase(-3)]
        [TestCase(-1)]
        public void TestSetterQuantity(int quantity)
        {

            Assert.Throws<ArgumentException>(() =>
            {
                var product = new Product("Product1", 3, quantity);
            }, "Price cannot be negative!");
        }

        [Test]
        public void ComaparingPriceShouldReturnGreaterPrice()
        {
            Product product1 = new Product("Product", 30, 5);
            Product product2 = new Product("Product", 20, 7);

            int result = product1.CompareTo(product2);

            Assert.That(result > 0, Is.True);

        }
    }
}