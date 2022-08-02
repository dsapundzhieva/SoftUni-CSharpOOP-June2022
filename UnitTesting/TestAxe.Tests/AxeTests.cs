using NUnit.Framework;
using System;

namespace TestAxe.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeLoosesDurabilityAfterEachAttack()
        {
            //Arrange
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            //Act
            axe.Attack(dummy);

            //Assert
            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn't change after attack.");
        }

        [Test]
        public void AttackWithZeroDurabilityThrowsException()
        {
            //Arrange
            Axe axe = new Axe(10, 0);
            Dummy dummy = new Dummy(10, 10);

            Assert.That(() =>
            {
                //Act & Assert
                axe.Attack(dummy);
            },
            Throws.Exception.TypeOf<InvalidOperationException>(),
            "Axe is broken");
        }
    }
}