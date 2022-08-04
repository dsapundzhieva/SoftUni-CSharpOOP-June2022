namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car = new Car("VW", "Golf", 15, 40);

        [Test]
        public void TestCarConstructorWorksProperly()
        {
            //Arrange
            string expectedMake = "VW";
            string expectedModel = "Golf";
            double expectedFuelConsumption = 4;
            double expectedFuelCapacity = 30;

           Car car = new Car(expectedMake, expectedModel, expectedFuelConsumption, expectedFuelCapacity);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedMake, car.Make);
                Assert.AreEqual(expectedModel, car.Model);
                Assert.AreEqual(expectedFuelConsumption, car.FuelConsumption);
                Assert.AreEqual(expectedFuelCapacity, car.FuelCapacity);
            });
        }

        [TestCase("", "Golf", 4, 40)]
        [TestCase(null, "Golf", 4, 40)]
        [TestCase("VW", "", 4, 40)]
        [TestCase("VW", null, 4, 40)]
        [TestCase("VW", "Golf", 0, 40)]
        [TestCase("VW", "Golf", -1, 40)]
        [TestCase("VW", "Golf", 8, -9)]
        public void TestCarConstructorThrowsError(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            });
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        public void RefuelCarWithNegativeAmountShouldThrowException(double fuelToRefuel)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.car.Refuel(fuelToRefuel);
            }, "Fuel amount cannot be zero or negative!");
        }

        [TestCase(1, 30)]
        [TestCase(10, 30)]
        [TestCase(30, 30)]
        public void RefuelCarWithPositeveAmountShouldSetCorrectlyFuelAmount(double fuelToRefuel, double fuelCapacity)
        {
            Car car = new Car("VW", "Golf", 5, fuelCapacity);
            car.Refuel(fuelToRefuel);

            Assert.AreEqual(fuelToRefuel, car.FuelAmount);
        }

        [TestCase(40, 30)]
        [TestCase(50, 30)]
        [TestCase(10.5, 10)]
        public void RefuelCarWithGreaterAmountThanCapacityShouldSetCorrectlyFuelAmount(double fuelToRefuel, double fuelCapacity)
        {
            Car car = new Car("VW", "Golf", 5, fuelCapacity);
            car.Refuel(fuelToRefuel);

            Assert.AreEqual(fuelCapacity, car.FuelAmount);
        }

        [TestCase(50)]
        [TestCase(100)]
        [TestCase(0)]
        [TestCase(1)]
        public void DriveCarWithNeededFuelAmount(double distance)
        {
            double fuelNeeded = (distance / 100) * this.car.FuelConsumption;

            this.car.Refuel(fuelNeeded + 100);
            
            double expectedAmount = this.car.FuelAmount - fuelNeeded;

            this.car.Drive(distance);

            Assert.AreEqual(expectedAmount, this.car.FuelAmount);
        }

        [TestCase(500)]
        [TestCase(400)]
        [TestCase(280)]
        public void DriveCarWithoutNeededFuelAmount(double distance)
        {
            double fuelNeeded = (distance / 100) * this.car.FuelConsumption;

            this.car.Refuel(10);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.car.Drive(distance);
            }, "You don't have enough fuel to drive!");
        }


    }
}