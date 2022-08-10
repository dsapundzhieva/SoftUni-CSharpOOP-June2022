using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            [Test]
            public void GarageNameShouldThrowExceptionWithEmptyAndNullValues()
            {
                Assert.Throws<ArgumentNullException>(() =>
                {
                    var garage = new Garage(null, 7);
                }, "Invalid garage name.");

                Assert.Throws<ArgumentNullException>(() =>
                {
                    var garage = new Garage(string.Empty, 7);
                }, "Invalid garage name.");
            }

            [Test]
            public void GarageNamePropertyShouldWorkCorrectly()
            {
                string expectedName = "Test";
                var garage = new Garage(expectedName, 19);


                Assert.AreEqual(expectedName, garage.Name);
            }

            [Test]
            public void GarageMechanicsShouldThrowExceptionWithNoMechanics()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    var garage = new Garage("Test", 0);
                }, "At least one mechanic must work in the garage.");

                Assert.Throws<ArgumentException>(() =>
                {
                    var garage = new Garage("Test", -9);
                }, "At least one mechanic must work in the garage.");
            }

            [Test]
            public void GarageMechanicsPropertyShouldWorkCorrectly()
            {
                int expectedMechanics = 7;
                var garage = new Garage("Test", expectedMechanics);

                Assert.AreEqual(expectedMechanics, garage.MechanicsAvailable);
            }

            [Test]
            public void GarageAddCarShouldThrowExceptionWithNoAvailableMechanics()
            {
                var garage = new Garage("Test", 1);
                var firstCar = new Car("VW", 10);
                var secondCar = new Car("Mercedes", 15);

                garage.AddCar(firstCar);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.AddCar(secondCar);
                }, "No mechanic available.");
            }

            [Test]
            public void GarageAddCarShouldIncrementCorrectCarCount()
            {
                var garage = new Garage("Test", 3);
                var firstCar = new Car("VW", 10);
                var secondCar = new Car("Mercedes", 15);

                garage.AddCar(firstCar);
                garage.AddCar(secondCar);

                Assert.AreEqual(2, garage.CarsInGarage);
            }

            [Test]
            public void GarageFixCarShouldThrowExceptionIfCarModelIsMissing()
            {
                var garage = new Garage("Test", 3);
                var firstCar = new Car("VW", 10);
                var secondCar = new Car("Mercedes", 15);

                garage.AddCar(firstCar);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.FixCar("Mercedes");
                }, $"The car {secondCar.CarModel} doesn't exist.");
            }

            [Test]
            public void GarageFixCarShouldReturnFixedCarIfExists()
            {
                const string carName = "VW";
                var garage = new Garage("Test", 3);

                var firstCar = new Car("VW", 10);
                var secondCar = new Car("Mercedes", 15);

                garage.AddCar(firstCar);
                Car actualFixedCar = garage.FixCar(carName);

                Assert.AreEqual(firstCar, actualFixedCar);
                Assert.That(actualFixedCar.IsFixed, Is.True);
                Assert.That(actualFixedCar.NumberOfIssues, Is.EqualTo(0));
                Assert.That(actualFixedCar.CarModel, Is.EqualTo(carName));
            }

            [Test]
            public void GarageRemoveFixedCarShouldThrowExceptionIfThereAreNoFixedCars()
            {
                var garage = new Garage("Test", 3);
                var firstCar = new Car("VW", 10);
                var secondCar = new Car("Mercedes", 15);

                garage.AddCar(firstCar);
                garage.AddCar(secondCar);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.RemoveFixedCar();
                }, $"No fixed cars available.");
            }

            [Test]
            public void GarageRemoveFixedCarShouldRemoveFixedCars()
            {
                //Arrange
                var garage = new Garage("Test", 3);

                var firstCar = new Car("VW", 10);
                var secondCar = new Car("Mercedes", 15);
                var thirdCar = new Car("BMW", 50);


                //Act
                garage.AddCar(firstCar);
                garage.AddCar(secondCar);
                garage.AddCar(thirdCar);
                garage.FixCar(firstCar.CarModel);
                int actualRemovedCars = garage.RemoveFixedCar();

                //Assert
                Assert.That(actualRemovedCars, Is.EqualTo(1));
                Assert.That(garage.CarsInGarage, Is.EqualTo(2));

            }

            [Test]
            public void GarageReportShouldFindAllNotFixedCars()
            {
                //Arrange
                var garage = new Garage("Test", 3);

                var firstCar = new Car("VW", 10);
                var secondCar = new Car("Mercedes", 15);
                var thirdCar = new Car("BMW", 50);

                //Act
                garage.AddCar(firstCar);
                garage.AddCar(secondCar);
                garage.AddCar(thirdCar);
                garage.FixCar(firstCar.CarModel);

                var report = garage.Report();

                Assert.That(report, Is.EqualTo($"There are 2 which are not fixed: Mercedes, BMW."));
            }
        }
    }
}