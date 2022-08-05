namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
            this.arena = new Arena();
        }

        [Test]
        public void TestConstructorInitializesEmptyCollectionOfWarrior()
        {
            Arena testArena = new Arena();

            List<Warrior> expectedWarriorList = new List<Warrior>();

            List<Warrior> actualWarriorList = testArena.Warriors.ToList();

            CollectionAssert.AreEqual(expectedWarriorList, actualWarriorList,
                "Arena constructor should initialize an empty collection for Warriors!");
        }

        [Test]
        public void CountShouldReturnZeroOnEmptyArena()
        {
            int expectedCount = 0;
            int actualCount = this.arena.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void CountShouldReturnCorrectValueWhenThereAreEnrolledWarriors()
        {
            Warrior warrior1 = new Warrior("Pesho", 33, 55);
            Warrior warrior2 = new Warrior("Gosho", 55, 35);

            this.arena.Enroll(warrior1);
            this.arena.Enroll(warrior2);

            Assert.AreEqual(2, this.arena.Count);
        }

        [Test]
        public void EnrollWarriorsWithSameNamesShouldTtrowException()
        {
            Warrior warrior1 = new Warrior("Pesho", 33, 55);
            Warrior warrior2 = new Warrior("Gosho", 35, 33);
            this.arena.Enroll(warrior1);
            this.arena.Enroll(warrior2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(warrior1);
            }, "Warrior is already enrolled for the fights!");
        }

        [Test]
        public void FightBetweenNonExistingAttackerShouldThrowException()
        {
            Warrior warrior = new Warrior("Pesho", 55, 45);

            this.arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight("Invalid", warrior.Name);

            }, "There is no fighter with name Invalid enrolled for the fights!");
        }

        [Test]
        public void FightBetweenNonExistingDefenderShouldThrowException()
        {
            Warrior warrior = new Warrior("Pesho", 55, 45);

            this.arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(warrior.Name, "Invalid");

            }, "There is no fighter with name Invalid enrolled for the fights!");
        }

        [Test]
        public void FightBetweenAttackerAndDefender()
        {
            Warrior warriorA = new Warrior("Pesho", 50, 100);
            Warrior warriorD = new Warrior("Gosho", 40, 100);

            this.arena.Enroll(warriorA);
            this.arena.Enroll(warriorD);

            this.arena.Fight(warriorA.Name, warriorD.Name);

            int actualAttackerHP = warriorA.HP;
            int expectedAttackerHP = 100 - warriorD.Damage;

            int actualDefenderHP = warriorD.HP;
            int expectedDefenderHP = 100 - warriorA.Damage;

            Assert.AreEqual(expectedAttackerHP, actualAttackerHP);
            Assert.AreEqual(expectedDefenderHP, actualDefenderHP);
        }
    }
}
