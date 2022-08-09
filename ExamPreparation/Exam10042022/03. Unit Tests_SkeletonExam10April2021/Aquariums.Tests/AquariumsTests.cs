namespace Aquariums.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class AquariumsTests
    {
        [Test]
        public void AquariumNameShouldThrowExceptionWithEmptyAndNullValues()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var aquarium = new Aquarium(string.Empty, 5);
            }, "Invalid aquarium name!");

            Assert.Throws<ArgumentNullException>(() =>
            {
                var aquarium = new Aquarium(null, 5);
            }, "Invalid aquarium name!");
        }

        [Test]
        public void AquariumNamePropertyShouldWorkCorrectly()
        {
            string expectedName = "Test";
            var aquarium = new Aquarium(expectedName, 5);

            Assert.That(aquarium.Name, Is.EqualTo(expectedName));
        }

        [Test]
        public void AquariumCapacityShouldThrowExceptionWithNegativeCapacity()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var aquarium = new Aquarium("Test", -5);
            }, "Invalid aquarium capacity!");
        }

        [Test]
        public void AquariumCapacityPropertyShouldWorkCorrectly()
        {
            int expectedCapacity = 10;
            var aquarium = new Aquarium("Test", expectedCapacity);

            Assert.That(aquarium.Capacity, Is.EqualTo(expectedCapacity));
        }

        [Test]
        public void AquariumAddFishShouldThrowExceptionWithFullCapacity()
        {
            //Arrange
            var aquarium = new Aquarium("Test", 2);

            var firstFish = new Fish("Test1");
            var secondFish = new Fish("Test2");
            var thirdFish = new Fish("Test2");

            //Act
            aquarium.Add(firstFish);
            aquarium.Add(secondFish);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(thirdFish);

            }, "Aquarium is full!");
        }

        [Test]
        public void AquariumAddFishShouldIncrementCountCorrectly()
        {
            //Arrange
            var aquarium = new Aquarium("Test", 3);
            
            var firstFish = new Fish("Test1");
            var secondFish = new Fish("Test2");
            var thirdFish = new Fish("Test3");
            List<Fish> fishList = new List<Fish>()
            {
                firstFish,
                secondFish,
                thirdFish
            };

            //Act
            aquarium.Add(firstFish);
            aquarium.Add(secondFish);
            aquarium.Add(thirdFish);

            Assert.That(aquarium.Count, Is.EqualTo(3));
            Assert.That(fishList.Count, Is.EqualTo(3));
        }

        [Test]
        public void AquariumRemoveFishShouldThrowExceptionWithNonExistingFishName()
        {
            //Arrange
            const string name = "Test2";
            var aquarium = new Aquarium("Test", 2);

            var firstFish = new Fish("Test1");
            
            //Act
            aquarium.Add(firstFish);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.RemoveFish(name);

            }, $"Fish with the name {name} doesn't exist!");
        }

        [Test]
        public void AquariumRemoveFishShouldRemoveExistingFish()
        {
            //Arrange
            var aquarium = new Aquarium("Test", 3);

            var firstFish = new Fish("Test1");
            var secondFish = new Fish("Test2");
            var thirdFish = new Fish("Test3");
           
            //Act
            aquarium.Add(firstFish);
            aquarium.Add(secondFish);
            aquarium.Add(thirdFish);

            aquarium.RemoveFish(firstFish.Name);

            Assert.That(aquarium.Count, Is.EqualTo(2));
        }

        [Test]
        public void AquariumSellFishShouldThrowExceptionWithNonExistingFishName()
        {
            //Arrange
            const string name = "Test2";
            var aquarium = new Aquarium("Test", 2);

            var firstFish = new Fish("Test1");

            //Act
            aquarium.Add(firstFish);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.SellFish(name);

            }, $"Fish with the name {name} doesn't exist!");
        }

        [Test]
        public void AquariumSellFishShouldWorkCorrectly()
        {
            //Arrange
            var aquarium = new Aquarium("Test", 3);

            var firstFish = new Fish("Test1");
            var secondFish = new Fish("Test2");
            var thirdFish = new Fish("Test3");

            //Act
            aquarium.Add(firstFish);
            aquarium.Add(secondFish);
            aquarium.Add(thirdFish);

            var soldFish = aquarium.SellFish(firstFish.Name);

            Assert.That(soldFish.Available, Is.False);
            Assert.That(soldFish.Name, Is.EqualTo(firstFish.Name));
        }

        [Test]
        public void AquariumReportShouldPrintAllFishes()
        {
            //Arrange
            var aquarium = new Aquarium("Test", 3);

            var firstFish = new Fish("Test1");
            var secondFish = new Fish("Test2");
            var thirdFish = new Fish("Test3");

            //Act
            aquarium.Add(firstFish);
            aquarium.Add(secondFish);
            aquarium.Add(thirdFish);

            var report = aquarium.Report();

            Assert.That(report, Is.EqualTo($"Fish available at Test: Test1, Test2, Test3"));
        }
    }
}
