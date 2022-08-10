using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Computers.Tests
{
    public class Tests
    {
        [Test]
        public void ComputerManagerCountShouldWorkCorrectly()
        {
            var computer = new Computer("Test", "Asos", 222);

            List<Computer> expectedList = new List<Computer>()
            {
                computer,
            };

            var computerManager = new ComputerManager();

            computerManager.AddComputer(computer);

            Assert.That(computerManager.Count, Is.EqualTo(1));
            CollectionAssert.AreEqual(expectedList, computerManager.Computers);
        }

        [Test]
        public void ComputerManagerEmptyCollection()
        {
            List<Computer> expectedList = new List<Computer>()
            {
            };

            var computerManager = new ComputerManager();

            Assert.That(computerManager.Count, Is.EqualTo(0));
            CollectionAssert.AreEqual(expectedList, computerManager.Computers);
        }


        [Test]
        public void ComputerManagerAddComputerShouldThrowExceptionIfComputerExists()
        {
            var computer1 = new Computer("Test", "Asos", 222);
            var computer2 = new Computer("Test", "Asos", 333);

            var computerManager = new ComputerManager();

            computerManager.AddComputer(computer1);

            Assert.Throws<ArgumentException>(() =>
            {
                computerManager.AddComputer(computer2);

            }, "This computer already exists.");
        }

        [Test]
        public void ComputerManagerAddCopmuterShouldThrowExceptionWithNullComputer()
        {
            var computer1 = new Computer("Test1", "Asos", 222);
            var computer2 = new Computer("Test2", "Asos", 333);

            var computerManager = new ComputerManager();
            computerManager.AddComputer(computer1);
            computerManager.AddComputer(computer2);


            Assert.Throws<ArgumentNullException>(() =>
            {
                computerManager.AddComputer(null);
            }, "Can not be null!");
        }

        [Test]
        public void ComputerManagerAddCopmuterShouldAddComputerCorrectly()
        {
            var computer1 = new Computer("Test1", "Asos", 222);
            var computer2 = new Computer("Test2", "Asos", 333);
            var computer3 = new Computer("Test2", "Apple", 333);


            var computerManager = new ComputerManager();

            computerManager.AddComputer(computer1);
            computerManager.AddComputer(computer2);
            computerManager.AddComputer(computer3);

            List<Computer> expectedComputers = new List<Computer>()
            {
                computer1,
                computer2,
                computer3
            };

            Assert.That(computerManager.Count, Is.EqualTo(3));
            CollectionAssert.AreEqual(expectedComputers, computerManager.Computers);
        }

        [Test]
        public void ComputerManagerRemoveComputerShouldThrowExceptionIfComputerDoesNotExists()
        {
            var computer1 = new Computer("Test1", "Asos", 222);
            var computer2 = new Computer("Test2", "Asos", 333);

            var computerManager = new ComputerManager();

            computerManager.AddComputer(computer1);

            Assert.Throws<ArgumentException>(() =>
            {
                computerManager.RemoveComputer("Test3", "Asos");

            }, "The computer does not exists.");
        }

        [Test]
        public void ComputerManagerRemoveComputerShouldRemoveComputerSuccessfuly()
        {
            const string expectedManufactorer = "Test1";
            const string expectedModel = "Asos";

            var computer1 = new Computer(expectedManufactorer, expectedModel, 222);
            var computer2 = new Computer("Test2", "Asos", 333);

            var computerManager = new ComputerManager();

            computerManager.AddComputer(computer1);
            computerManager.AddComputer(computer2);

            var removedComputer = computerManager.RemoveComputer(expectedManufactorer, expectedModel);

            Assert.That(removedComputer.Manufacturer, Is.EqualTo(expectedManufactorer));
            Assert.That(removedComputer.Model, Is.EqualTo(expectedModel));
            Assert.That(computerManager.Count, Is.EqualTo(1));
        }

        [Test]
        public void ComputerManagerGetComputerShouldThrowExceptionWithNullManufacturerOrModel()
        {
            var computer1 = new Computer("Test1", "Asos", 222);
            var computer2 = new Computer("Test2", "Asos", 333);

            var computerManager = new ComputerManager();
            computerManager.AddComputer(computer1);
            computerManager.AddComputer(computer2);


            Assert.Throws<ArgumentNullException>(() =>
            {
                computerManager.GetComputer(null, computer1.Model);
            }, "Can not be null!");

            Assert.Throws<ArgumentNullException>(() =>
            {
                computerManager.GetComputer("Test2", null);
            }, "Can not be null!");
        }

        [Test]
        public void ComputerManagerGetComputerShouldThrowExceptionWithWrongManufacturerAndModel()
        {
            var computer1 = new Computer("Test1", "Asos", 222);
            var computer2 = new Computer("Test2", "Asos", 333);

            var computerManager = new ComputerManager();
            computerManager.AddComputer(computer1);
            computerManager.AddComputer(computer2);


            Assert.Throws<ArgumentException>(() =>
            {
                computerManager.GetComputer("Test3", "Apple");
            }, "There is no computer with this manufacturer and model.");
        }

        [Test]
        public void ComputerManagerGetComputerShouldWorkCorrectly()
        {
            var computer1 = new Computer("Test1", "Assos", 222);
            var computer2 = new Computer("Test2", "Assos", 333);

            var computerManager = new ComputerManager();
            computerManager.AddComputer(computer1);
            computerManager.AddComputer(computer2);

            var computer = computerManager.GetComputer("Test1", "Assos");

            Assert.That(computer.Manufacturer, Is.EqualTo(computer1.Manufacturer));
            Assert.That(computer.Model, Is.EqualTo(computer1.Model));
            Assert.That(computer.Price, Is.EqualTo(computer1.Price));
        }

        [Test]
        public void ComputerManagerGetComputersByManufacturerShouldThrowExceptionWithNullManufacturer()
        {
            var computer1 = new Computer("Test1", "Asos", 222);
            var computer2 = new Computer("Test2", "Asos", 333);

            var computerManager = new ComputerManager();
            computerManager.AddComputer(computer1);
            computerManager.AddComputer(computer2);


            Assert.Throws<ArgumentNullException>(() =>
            {
                computerManager.GetComputersByManufacturer(null);
            }, "Can not be null!");
        }

        [Test]
        public void ComputerManagerGetComputersByManufacturerShouldWorkCorrectly()
        {
            var computer1 = new Computer("Test1", "Assos", 222);
            var computer2 = new Computer("Test2", "Assos", 333);
            var computer3 = new Computer("Test1", "Apple", 222);
            var computer4 = new Computer("Test1", "Dell", 444);


            var computerManager = new ComputerManager();
            computerManager.AddComputer(computer1);
            computerManager.AddComputer(computer2);
            computerManager.AddComputer(computer3);
            computerManager.AddComputer(computer4);

            List<Computer> expectedComputersByManufacturer = new List<Computer>()
            {
                computer1,
                computer3,
                computer4
            };

            var computersByManufacturer = computerManager.GetComputersByManufacturer("Test1");

            CollectionAssert.AreEqual(expectedComputersByManufacturer, computersByManufacturer);
            Assert.That(computersByManufacturer.Count, Is.EqualTo(3));
        }
    }
}