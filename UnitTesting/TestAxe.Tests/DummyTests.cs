using NUnit.Framework;
using System;

namespace TestAxe.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyLoosesHealthAfterAttack()
        {
            //Arrange
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(20, 20);

            //Act
            axe.Attack(dummy);

            //Assert
            Assert.That(dummy.Health, Is.EqualTo(10), "Dummy is dead.");
        }

        [Test]
        public void DeadDummyThrowsExceptionAfterAttack()
        {
            //Arrange
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(0, 20);

            Assert.That(() =>
            {
                //Act & Assert
                axe.Attack(dummy);
            },
           Throws.Exception.TypeOf<InvalidOperationException>(),
           "Dummy is dead.");
        }

        [Test]
        public void DeadDummyGiveExprience()
        {
            //Arrange
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 20);

            //Act
            axe.Attack(dummy);
            dummy.GiveExperience();

            //Assert
            Assert.That(dummy.GiveExperience, Is.EqualTo(20), "Target is not dead.");
        }

        [Test]
        public void AliveDummyExperienceThrowsException()
        {
            //Arrange
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(20, 20);
            axe.Attack(dummy);

            Assert.That(() =>
            {
                //Act & Assert
                dummy.GiveExperience();
            },
         Throws.Exception.TypeOf<InvalidOperationException>(),
         "Target is not dead.");
        }
    }
}