namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Reflection;

    [TestFixture]
    public class WarriorTests
    {

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            string expectedName = "Pesho";
            int expectedDamage = 55;
            int expectedHP = 30;

            Warrior warrior = new Warrior(expectedName, expectedDamage, expectedHP);

            string actualName = warrior.Name;
            int actualDamage = warrior.Damage;
            int actualHP = warrior.HP;

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedName, actualName);
                Assert.AreEqual(expectedDamage, actualDamage);
                Assert.AreEqual(expectedHP, actualHP);
            });

        }

        [Test]
        public void TestNameGetter()
        {
            string expectedName = "Pesho";
            Warrior warrior = new Warrior(expectedName, 55, 33);

            string actualName = warrior.Name;
            Assert.AreEqual(expectedName, actualName);
        }

        [TestCase("")]
        [TestCase("             ")]
        [TestCase(null)]
        public void TestNameSetterValidation(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, 33, 55);
            }, "Name should not be empty or whitespace!");
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-100)]
        public void TestDamageSetterValidation(int damage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", damage, 55);
            }, "Damage value should be positive!");
        }

        [TestCase(-1)]
        [TestCase(-100)]
        public void TestHPSetterValidation(int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", 33, hp);
            }, "HP should not be negative!");
        }

        [TestCase(30)]
        [TestCase(20)]
        public void WarriorWithLessThan30HPCannotAttack(int hp)
        {
            Warrior warriorA = new Warrior("Pesho", 33, hp);
            Warrior warriorD = new Warrior("Pesho", 33, 55);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warriorA.Attack(warriorD);
            }, "Your HP is too low in order to attack other warriors!");
        }

        [TestCase(30)]
        [TestCase(20)]
        public void WarriorWithLessThan30HPCannotDefend(int hp)
        {
            Warrior warriorA = new Warrior("Pesho", 33, 55);
            Warrior warriorD = new Warrior("Pesho", 33, hp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warriorA.Attack(warriorD);
            }, "Enemy HP must be greater than 30 in order to attack him!");
        }

        [TestCase(35, 55)]
        [TestCase(31, 32)]
        public void WarriorWithLessHPThanTheDefenderDamageShouldThrowError(int hp, int damage)
        {
            Warrior warriorA = new Warrior("Pesho", 33, hp);
            Warrior warriorD = new Warrior("Pesho", damage, 55);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warriorA.Attack(warriorD);
            }, "You are trying to attack too strong enemy");
        }

        [TestCase(55, 35)]
        [TestCase(46, 40)]
        public void WarriorHpShouldDecreaseWhenAttack(int hp, int damage)
        {
            Warrior warriorA = new Warrior("Pesho", 33, hp);
            Warrior warriorD = new Warrior("Pesho", damage, 55);

            warriorA.Attack(warriorD);
            int expectedHP = hp - damage;

            Assert.AreEqual(expectedHP, warriorA.HP);
        }

        [TestCase(50, 40)]
        [TestCase(32, 31)]
        public void SucessAttackShouldKillEnemyIfMyDamageIsOverTheirHP(int damageA, int hpD)
        {
            Warrior warriorA = new Warrior("Pesho", damageA, 33);
            Warrior warriorD = new Warrior("Pesho", 33, hpD);

            warriorA.Attack(warriorD);
            
            Assert.AreEqual(0, warriorD.HP);
        }
    }
}