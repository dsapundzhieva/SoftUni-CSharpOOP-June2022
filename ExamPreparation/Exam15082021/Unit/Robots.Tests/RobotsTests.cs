namespace Robots.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class RobotsTests
    {
        [Test]
        public void ConstructorShouldInitializeCorrectlyAllProperties()
        {
            int capacity = 10;
            var robotManager = new RobotManager(capacity);

            int expectedCapacity = 10;

            int actualCapacity = robotManager.Capacity;

            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        [Test]
        public void CapacityShouldThrowExceptionIfIsNull()
        {
            Assert.Throws<ArgumentException>(() =>
            new RobotManager(-1));
        }

        [Test]
        public void AddRobotShouldThrowExceptionWhenCollectionContainsSameRobot()
        {
            var robotManager = new RobotManager(5);
            var robot = new Robot("TestName", 10);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(()
                => robotManager.Add(robot));
        }

        [Test]
        public void AddRobotShouldThrowExceptionWhenCapacityIsInvalid()
        {
            var robotManager = new RobotManager(0);
            var robot = new Robot("TestName", 10);


            Assert.Throws<InvalidOperationException>(()
                => robotManager.Add(robot));
        }

        [Test]
        public void AddRobotShouldAddRobotnWhenCapacityIsValid()
        {
            var robotManager = new RobotManager(3);
            var robot = new Robot("TestName", 10);

            robotManager.Add(robot);

            var expectedCount = 1;
            var actualCount = robotManager.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemoveRobotShouldThrowExceptionWhenRobotIsNull()
        {
            var robotManager = new RobotManager(10);

            Assert.Throws<InvalidOperationException>(()
                => robotManager.Remove("RoboTest"));
        }

        [Test]
        public void RemoveShouldRemoveRobotWhenNameIsCorrect()
        {
            var robotManager = new RobotManager(2);
            var robot = new Robot("TestName", 10);

            robotManager.Add(robot);
            robotManager.Remove("TestName");

            var expextedCount = 0;
            var actualCount = robotManager.Count;

            Assert.AreEqual(expextedCount, actualCount);
        }

        [Test]
        public void WorkShouldThrowExceptionWhenIsNameNotFound()
        {
            var robotManager = new RobotManager(10);

            Assert.Throws<InvalidOperationException>(()
                => robotManager.Work("None", "Job", 5));
        }

        [Test]
        public void WorkShouldThrowExceptionWhenBaterryIsLow()
        {
            var robotManager = new RobotManager(4);
            var robot = new Robot("TestName", 5);

            Assert.Throws<InvalidOperationException>(()
                => robotManager.Work("TestName", "Job", 10));
        }

        [Test]
        public void WorkShouldDecreaseBattery()
        {
            var robotManager = new RobotManager(10);
            var robot = new Robot("TestName", 10);

            robotManager.Add(robot);
            robotManager.Work("TestName", "None", 5);

            var expectedBattery = 5;
            var actualBattery = robot.Battery;

            Assert.AreEqual(expectedBattery, actualBattery);
        }

        [Test]
        public void ChargeShouldThrowExceptionWhenRobotIsNotFound()
        {
            var robotManager = new RobotManager(10);

            Assert.Throws<InvalidOperationException>(()
                => robotManager.Charge("TestName"));
        }

        [Test]
        public void ThrowsExceptionWhenCurrentBatteryUsageIsLessThanExpected()
        {
            var robotManager = new RobotManager(10);
            var robot = new Robot("Test", 10);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => robotManager.Work("Test", "manager", 1000));
        }

        [Test]
        public void ChargeShouldChargeRobot()
        {
            var robotManager = new RobotManager(10);
            var robot = new Robot("Test", 10);

            robot.Battery = 5;

            robotManager.Add(robot);
            robotManager.Charge("Test");

            var expectedBattery = 10;
            var actualBattery = robot.Battery;

            Assert.AreEqual(expectedBattery, actualBattery);
        }
    }
}
