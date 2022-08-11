using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {

        [Test]
        public void ShopCapacityShouldThrowExceptionWithNegativeCapacity()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Shop shop = new Shop(-100);
            });
        }

        [Test]
        public void ShopCapacityShouldInitializeCapacityCorrectly()
        {
            Shop shop = new Shop(100);

            Assert.That(shop.Capacity, Is.EqualTo(100));
        }

        [Test]
        public void ShopAddShouldThrowExeptionWithExistingSmartphone()
        {
            Shop shop = new Shop(5);
            Smartphone smartphone1 = new Smartphone("Apple", 100);

            shop.Add(smartphone1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(smartphone1);
            });

        }

        [Test]
        public void ShopAddShouldThrowExeptionWithFullCapacity()
        {
            Shop shop = new Shop(0);
            Smartphone smartphone1 = new Smartphone("IPhone11", 100);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(smartphone1);
            });
        }


        [Test]
        public void ShopAddShouldAddPhoneCorrectly()
        {
            Shop shop = new Shop(2);

            Smartphone smartphone1 = new Smartphone("IPhone11", 100);
            Smartphone smartphone2 = new Smartphone("IPhone12", 50);
            Smartphone smartphone3 = new Smartphone("IPhone13", 50);

            shop.Add(smartphone1);
            shop.Add(smartphone2);

            Assert.That(shop.Count, Is.EqualTo(2));
        }

        [Test]
        public void ShopRemoveShouldThrowExeptionWithNonExistingPhone()
        {
            Shop shop = new Shop(2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove("Samsung");
            });
        }

        [Test]
        public void ShopRemoveShouldRemovePhoneCorrectly()
        {
            Shop shop = new Shop(2);

            Smartphone smartphone1 = new Smartphone("IPhone11", 100);
            Smartphone smartphone2 = new Smartphone("IPhone12", 50);
            Smartphone smartphone3 = new Smartphone("IPhone13", 50);

            shop.Add(smartphone1);
            shop.Add(smartphone2);

            shop.Remove("IPhone11");

            Assert.That(shop.Count, Is.EqualTo(1));
            Assert.That(smartphone1.ModelName, Is.EqualTo("IPhone11"));
        }

        [Test]
        public void ShopTestPhoneShouldThrowExeptionWithNonExistingPhone()
        {
            Shop shop = new Shop(2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("Samsung", 100);
            });
        }

        [Test]
        public void ShopTestPhoneShouldThrowExeptionWithLowBattery()
        {
            Shop shop = new Shop(10);
            Smartphone smartphone1 = new Smartphone("IPhone11", 10);
            Smartphone smartphone2 = new Smartphone("IPhone12", 50);
        
            shop.Add(smartphone1);
            shop.Add(smartphone2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("IPhone11", 1000);
            });
        }

        [Test]
        public void ShopShouldThrowExeptionWhenCurrentBatteryUsageIsLessThanExpected()
        {
            Shop shop = new Shop(10);
            Smartphone smartphone1 = new Smartphone("IPhone11", 10);

            shop.Add(smartphone1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("IPhone11", 1000);
            });
        }

        [Test]
        public void ShopTestPhoneShouldWorkCorrectly()
        {
            Shop shop = new Shop(2);

            Smartphone smartphone1 = new Smartphone("IPhone11", 100);
            Smartphone smartphone2 = new Smartphone("IPhone12", 50);
            Smartphone smartphone3 = new Smartphone("IPhone13", 50);

            shop.Add(smartphone1);
            shop.Add(smartphone2);

            shop.TestPhone("IPhone11", 90);

            Assert.That(smartphone1.ModelName, Is.EqualTo("IPhone11"));
            Assert.That(smartphone1.CurrentBateryCharge, Is.EqualTo(10));
        }

        [Test]
        public void ShopChargePhoneShouldThrowExeptionWithNonExistingPhone()
        {
            Shop shop = new Shop(2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.ChargePhone("Samsung");
            });
        }

        [Test]
        public void ShopChargePhoneShouldWorkCorrectly()
        {
            Shop shop = new Shop(2);

            Smartphone smartphone1 = new Smartphone("IPhone11", 50);

            smartphone1.CurrentBateryCharge = 5;

            shop.Add(smartphone1);
            shop.ChargePhone("IPhone11");


            Assert.That(smartphone1.ModelName, Is.EqualTo("IPhone11"));
            Assert.That(smartphone1.CurrentBateryCharge, Is.EqualTo(50));
            Assert.That(smartphone1.MaximumBatteryCharge, Is.EqualTo(50));
        }
    }
}