namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class PresentsTests
    {
        [Test]
        public void BagCreateShouldThrowExceptionWithNoPresent()
        {
            Bag bag = new Bag();

            Assert.Throws<ArgumentNullException>(() =>
            {
                bag.Create(null);
            }, "Present is null");
        }

        [Test]
        public void BagCreateShouldThrowExceptionWithExistingPresent()
        {
            //Arrange
            Bag bag = new Bag();
            Present present1 = new Present("test1", 22);

            //Act
            bag.Create(present1);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                bag.Create(present1);
            }, "This present already exists!");
        }

        [Test]
        public void BagCreateShouldCreatePresentCorrectly()
        {
            //Arrange
            Bag bag = new Bag();
            Present present1 = new Present("test1", 22);
            Present present2 = new Present("test2", 22);

            List<Present> expectedCollection = new List<Present>()
            {
                present1,
                present2
            };

            //Act
            var result1 = bag.Create(present1);
            var result2 = bag.Create(present2);

            //Assert
            Assert.That(bag.GetPresents().Count, Is.EqualTo(2));
            CollectionAssert.AreEqual(expectedCollection, bag.GetPresents());
            Assert.That(result1, Is.EqualTo($"Successfully added present {present1.Name}."));
            Assert.That(result2, Is.EqualTo($"Successfully added present {present2.Name}."));
        }

        [Test]
        public void BagRemoveShouldThrowExceptionWithNonExistingPresent()
        {
            //Arrange
            Bag bag = new Bag();
            Present present1 = new Present("test1", 22);
            Present present2 = new Present("test2", 22);

            //Act
            bag.Create(present1);
            var result1 = bag.Remove(null);
            var result2 = bag.Remove(present2);

            //Assert
            Assert.That(result1, Is.False);
            Assert.That(result2, Is.False);
        }

        [Test]
        public void BagRemoveShouldWorkCorrectly()
        {
            //Arrange
            Bag bag = new Bag();
            Present present1 = new Present("test1", 22);
            Present present2 = new Present("test2", 22);

            //Act
            bag.Create(present1);
            var result1 = bag.Remove(present1);
            var result2 = bag.Remove(present2);

            //Assert
            Assert.That(result1, Is.True);
            Assert.That(result2, Is.False);
            Assert.That(bag.GetPresents().Count, Is.EqualTo(0));
        }

        [Test]
        public void BagGetPresentShouldReturnNullIfNoPresents()
        {
            var bag = new Bag();

            var presentResult1 = bag.GetPresent("Test1");
            var presentResult2 = bag.GetPresent("");

            Assert.That(presentResult1, Is.EqualTo(null));
            Assert.That(presentResult2, Is.EqualTo(null));
        }

        [Test]
        public void BagGetPresentShouldReturnTheCorrectPresent()
        {
            var bag = new Bag();

            Present present1 = new Present("Test1", 22);
            Present present2 = new Present("Test2", 22);

            //Act
            bag.Create(present1);
            bag.Create(present2);

            var presentResult1 = bag.GetPresent("Test1");
            var presentResult2 = bag.GetPresent("Test");

            Assert.That(presentResult1, Is.EqualTo(present1));
            Assert.That(presentResult1.Name, Is.EqualTo("Test1"));
            Assert.That(presentResult1.Magic, Is.EqualTo(22));
            Assert.That(presentResult2, Is.EqualTo(null));
        }

        [Test]
        public void BagGetPresentWithLeastMagicShouldReturnNullIfNoPresents()
        {
            var bag = new Bag();

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                var presentResult1 = bag.GetPresentWithLeastMagic();
            }, "There are noe sequence in the collection");
        }

        [Test]
        public void BagGetPresentWithLeastMagicShouldReturnTheCorrectPresent()
        {
            var bag = new Bag();

            Present present1 = new Present("Test1", 22);
            Present present2 = new Present("Test2", 23);
            Present present3 = new Present("Test3", 280);
            Present present4 = new Present("Test4", 0);

            //Act
            bag.Create(present1);
            bag.Create(present2);
            bag.Create(present3);
            bag.Create(present4);

            var presentResult = bag.GetPresentWithLeastMagic();

            Assert.That(presentResult, Is.EqualTo(present4));
            Assert.That(presentResult.Name, Is.EqualTo("Test4"));
            Assert.That(presentResult.Magic, Is.EqualTo(0));
        }

    }
}
