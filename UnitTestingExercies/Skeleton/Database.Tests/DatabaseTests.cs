namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class DatabaseTests
    {
        private Database db;
        [SetUp]
        public void SetUp()
        {
            this.db = new Database();
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void ConstructorShouldAddLessThan16Elements(int[] elementsToAdd)
        {
            //Arrange
            Database testDb = new Database(elementsToAdd);

            //Act
            int[] actualData = testDb.Fetch();
            int[] expectedData = elementsToAdd;

            int actualCount = testDb.Count;
            int expectedCount = expectedData.Length;

            //Assert
            CollectionAssert.AreEqual(expectedData, actualData,
                "Database constructor should initialize data field correctly!");
            Assert.AreEqual(expectedCount, actualCount,
                "Constructor should set initial value for the count field!");
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 18, 19, 20 })]
        public void ConstructorMustNotAllowToExceedMaxCount(int[] elementsToAdd)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database testDb = new Database(elementsToAdd);
            }, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void CountShouldReturnActualCount()
        {
            //Arrange
            int[] initData = new int[] { 1, 2, 4, 5 };
            Database testDb = new Database(initData);

            int actualCount = testDb.Count;
            int expectedCount = initData.Length;

            Assert.AreEqual(expectedCount, actualCount,
                "Count should return the count of the added elements!");
        }

        [Test]
        public void CountShouldReturnZeroWhenNoElements()
        {
            int actualCount = this.db.Count;
            int expectedCount = 0;

            //Assert
            Assert.AreEqual(expectedCount, actualCount,
                "Count should be zero when there are no elements!");
        }

        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void AddShouldAddLessThan16Elements(int[] elToAdd)
        {
            foreach (var el in elToAdd)
            {
                this.db.Add(el);
            }

            int[] actualData = this.db.Fetch();
            int[] expectedData = elToAdd;

            int actualCount = this.db.Count;
            int expectedCount = expectedData.Length;

            CollectionAssert.AreEqual(expectedData, actualData,
                "Add should physically add the elements!");

            Assert.AreEqual(expectedCount, actualCount,
                "Add should change the count when adding!");
        }

        [Test]
        public void AddShouldThrowExcetionWhenAddingMoreThan16Elements()
        {
            //Arange
            for (int i = 1; i <= 16; i++)
            {
                this.db.Add(i);
            }

            //Act && Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.db.Add(17);
            }, "Array's capacity must be exactly 16 integers!");
        }

        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1 })]
        public void RemoveShouldRemoveTheLastElementSuccessfully(int[] startElements)
        {
            foreach (var item in startElements)
            {
                this.db.Add(item);
            }
            this.db.Remove();
            List<int> elList = new List<int>(startElements);
            elList.RemoveAt(elList.Count - 1);

            int[] actualData = this.db.Fetch();
            int[] expectedData = elList.ToArray();

            int actualCount = actualData.Length;
            int expectedCount = expectedData.Length;

            CollectionAssert.AreEqual(expectedData, actualData,
                "Remove should remove the last element int the data field!");
            Assert.AreEqual(expectedCount, actualCount,
                "Remove shoud decrement the count of the Database!");
        }

        [Test]
        public void RemoveShouldRemoveTheLastElementMoreThanOnce()
        {
            List<int> initData = new List<int> { 1, 2, 3, 4, 5 };

            foreach (var el in initData)
            {
                this.db.Add(el);
            }
            for (int i = 0; i < initData.Count; i++)
            {
                this.db.Remove();
            }

            int[] actualData = this.db.Fetch();
            int[] expectedData = new int[] { };

            int actualCount = this.db.Count;
            int expectedCount = 0;

            CollectionAssert.AreEqual(expectedData, actualData,
                "Remove should remove the last element int the data field!");
            Assert.AreEqual(expectedCount, actualCount,
                "Remove shoud decrement the count of the Database!");
        }

        [Test]
        public void RemoveShouldThrowExcepionWhenNoElements()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.db.Remove();
            }, "The collection is empty!");
        }

        [TestCase(new int[] {})]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void FetchShouldReturnCopyArray(int[] initData)
        {
            foreach (var el in initData)
            {
                this.db.Add(el);
            }

            int[] actualData = this.db.Fetch();
            int[] expectedData = initData;

            CollectionAssert.AreEqual(expectedData, actualData,
                "Fetch should return copy of the array");
        }
    }


}
