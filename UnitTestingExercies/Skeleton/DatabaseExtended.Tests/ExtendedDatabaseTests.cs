namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database db = new Database();
        private Person[] people;

        [Test]
        public void TestPersonConstructorWorksProperly()
        {
            long expectedId = 123456790;
            string expectedUsername = "Pesho";

            Person person = new Person(expectedId, expectedUsername);

            Type type = typeof(Person);
            FieldInfo idField = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.Name == "id");
            long actualId = (long)idField.GetValue(person);

            FieldInfo usernameField = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.Name == "userName");
            string actualUsername = (string)usernameField.GetValue(person);

            Assert.AreEqual(expectedId, actualId,
                "Constructor should initialize the Id of the Preson!");
            Assert.AreEqual(expectedUsername, actualUsername,
                "Constructor should initialize the Username of the Preson!");
        }

        [Test]
        public void TestIdGetter()
        {
            long expectedId = 12346569;

            Person person = new Person(expectedId, "Pesho");

            long actualId = (long)person.Id;

            Assert.AreEqual(expectedId, actualId,
                "Getter of the property Id should return value of Id!");
        }

        [Test]
        public void TestUsernameGetter()
        {
            string expectedUsername = "Pesho";

            Person person = new Person(1234, expectedUsername);

            string actualUsername = person.UserName;

            Assert.AreEqual(expectedUsername, actualUsername,
                "Getter of the property Username should return value of Username!");
        }

        [Test]
        public void InitializeDatabaseWithEmptyConstructor()
        {
            Assert.DoesNotThrow(() =>
            {
                this.db = new Database();
            });
        }

        [TestCaseSource("TestCaseConstructorData")]
        public void InitializeDatabaseConstructorWithParameters(Person[] people, int expectedCount)
        {
            Database database = new Database(people);

            Assert.AreEqual(expectedCount, database.Count,
                "Constructor should intialize DB with the given collection and count!");
        }

        [TestCaseSource("TestCaseAddData")]
        public void AddUpTo16PersonsShouldSuccess(Person[] peopleCtor, Person[] peopleAdd, int expectedCount)
        {
            Database database = new Database(peopleCtor);

            foreach (var person in peopleAdd)
            {
                database.Add(person);
            }

            Assert.AreEqual(expectedCount, database.Count);
        }

        [TestCaseSource("TestCaseAddInvalidData")]
        public void AddMoreThan16PersonsShouldThrowException(Person[] peopleCtor, Person[] peopleAdd, Person newPerson)
        {
            Database database = new Database(peopleCtor);

            foreach (var person in peopleAdd)
            {
                database.Add(person);
            }
            Assert.Throws<InvalidOperationException>(() =>

                database.Add(newPerson));
        }

        [TestCaseSource("TestCaseRemoveData")]
        public void RemoveDataShouldSuccess(Person[] peopleCtor, Person[] peopleAdd, int removePeople, int expectedCount)
        {
            Database database = new Database(peopleCtor);

            foreach (var person in peopleAdd)
            {
                database.Add(person);
            }
            for (int i = 0; i < removePeople; i++)
            {
                database.Remove();
            }

            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void RemoveFromEmptyDatabaseShouldThrowException()
        {
            Database database = new Database();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [TestCase("")]
        [TestCase(null)]
        public void ThrowExceptionIfArgumentIsNullOrEmpty(string name)
        {
            //Arrange
            Person person = new Person(1, "Person");
            Database database = new Database();

            //Act
            database.Add(person);

            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                database.FindByUsername(name);
            },
            "Username parameter is null!");
        }

        [TestCase("Perso1")]
        [TestCase("Perso2")]
        public void ThrowExceptionIfDatabaseDoesNotContainUsername(string name)
        {
            //Arrange
            Person person = new Person(1, "Person");
            Database database = new Database();

            //Act
            database.Add(person);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindByUsername(name);
            },
            "No user is present by this username!");
        }

        [TestCaseSource("TestCaseFindPersonByName")]
        public void TestFindPersonByUsername(Person[] peopleCtor, string username)
        {
            Database database = new Database(peopleCtor);

            Person actualPersonToFind = database.FindByUsername(username);
            string expecctedPersonToFind = username;

            Assert.AreEqual(expecctedPersonToFind, actualPersonToFind.UserName);
        }

        [Test]
        public void ThrowExceptionIfPersonIdIsLessThan0()
        {
            Database database = new Database(new Person(3, "Person"));
            
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                database.FindById(-4);
            },
            "Id should be a positive number!");
        }

        [TestCase(56)]
        [TestCase(98)]
        public void ThrowExceptionIfDatabaseDoesNotContainId(long id)
        {
            //Arrange
            Person person = new Person(1, "Person");
            Database database = new Database();

            //Act
            database.Add(person);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindById(id);
            },
            "No user is present by this ID!");
        }

        [TestCaseSource("TestCaseFindPersonById")]
        public void TestFindPersonById(Person[] peopleCtor, long id)
        {
            Database database = new Database(peopleCtor);

            Person actualPersonToFind = database.FindById(id);
            long expecctedPersonToFind = id;

            Assert.AreEqual(expecctedPersonToFind, actualPersonToFind.Id);
        }

        public static IEnumerable<TestCaseData> TestCaseFindPersonById()
        {
            TestCaseData[] testCaseData = new TestCaseData[]
            {
                new TestCaseData(
                new Person[]
                {
                    new Person(1, "Person1"),
                    new Person(2, "Person2"),
                    new Person(3, "Person3"),
                    new Person(4, "Person4"),
                    new Person(5, "Person5"),
                    new Person(6, "Person6"),

                },
                2),
                new TestCaseData(
                     new Person[]
                       {
                        new Person(1, "Person1"),
                        new Person(2, "Person2"),
                        new Person(3, "Person3"),
                        new Person(4, "Person4"),
                        new Person(5, "Person5"),
                        new Person(6, "Person6"),
                       },
                     5)
            };

            foreach (var item in testCaseData)
            {
                yield return item;
            }
        }


        public static IEnumerable<TestCaseData> TestCaseFindPersonByName()
        {
            TestCaseData[] testCaseData = new TestCaseData[]
            {
                new TestCaseData(
                new Person[]
                {
                    new Person(1, "Person1"),
                    new Person(2, "Person2"),
                    new Person(3, "Person3"),
                    new Person(4, "Person4"),
                    new Person(5, "Person5"),
                    new Person(6, "Person6"),

                },
                "Person1"),
                new TestCaseData(
                     new Person[]
                       {
                        new Person(1, "Person1"),
                        new Person(2, "Person2"),
                        new Person(3, "Person3"),
                        new Person(4, "Person4"),
                        new Person(5, "Person5"),
                        new Person(6, "Person6"),
                       },
                     "Person6")
            };

            foreach (var item in testCaseData)
            {
                yield return item;
            }
        }


        public static IEnumerable<TestCaseData> TestCaseRemoveData()
        {
            TestCaseData[] testCaseData = new TestCaseData[]
            {
                new TestCaseData(
                new Person[]
                {
                    new Person(1, "Person1"),
                    new Person(2, "Person2"),
                    new Person(3, "Person3"),

                },
                 new Person[]
                {
                    new Person(4, "Person4"),
                    new Person(5, "Person5"),
                    new Person(6, "Person6"),

                },
                3,
                3),
                new TestCaseData(
                new Person[]
                {
                },
                 new Person[]
                {
                    new Person(4, "Person4"),
                    new Person(5, "Person5"),
                    new Person(6, "Person6"),

                },
                3,
                0)
            };

            foreach (var item in testCaseData)
            {
                yield return item;
            }
        }


        public static IEnumerable<TestCaseData> TestCaseAddInvalidData()
        {
            TestCaseData[] testCaseData = new TestCaseData[]
            {
                new TestCaseData(
                new Person[]
                {
                    new Person(1, "Person1"),
                    new Person(2, "Person2"),
                    new Person(3, "Person3"),
                    new Person(4, "Person4"),
                    new Person(5, "Person5"),
                    new Person(6, "Person6"),
                    new Person(7, "Person7"),
                    new Person(8, "Person8"),
                    new Person(9, "Person9"),
                    new Person(10, "Person10"),
                    new Person(11, "Person11"),
                    new Person(12, "Person12"),
                    new Person(13, "Person13"),
                },
                    new Person[]
                {
                    new Person(14, "Person14"),
                    new Person(15, "Person15"),
                    new Person(16, "Person16"),
                },
                    new Person(17, "Person17")
                    ),
                new TestCaseData(
                    new Person[]
                     {
                     },
                     new Person[]
                       {
                        new Person(1, "Person1"),
                        new Person(2, "Person2"),
                        new Person(3, "Person3"),
                       },
                        new Person(4, "Person1")
                     ),
                new TestCaseData(
                    new Person[]
                     {
                     },
                     new Person[]
                       {
                        new Person(1, "Person1"),
                        new Person(2, "Person2"),
                        new Person(3, "Person3"),
                       },
                        new Person(3, "Person4")
                     )
            };

            foreach (var item in testCaseData)
            {
                yield return item;
            }
        }


        public static IEnumerable<TestCaseData> TestCaseAddData()
        {
            TestCaseData[] testCaseData = new TestCaseData[]
            {
                new TestCaseData(
                new Person[]
                {
                    new Person(1, "Person1"),
                    new Person(2, "Person2"),
                    new Person(3, "Person3"),

                },
                    new Person[]
                {
                    new Person(4, "Person4"),
                    new Person(5, "Person5"),
                    new Person(6, "Person6"),
                },
                6),
                new TestCaseData(
                     new Person[]
                       {
                       },
                     new Person[]
                     {
                    new Person(7, "Person7"),
                    new Person(8, "Person8"),
                    new Person(9, "Person9"),
                     },
                     3)
            };

            foreach (var item in testCaseData)
            {
                yield return item;
            }
        }


        public static IEnumerable<TestCaseData> TestCaseConstructorData()
        {
            TestCaseData[] testCaseData = new TestCaseData[]
            {
                new TestCaseData(
                new Person[]
                {
                    new Person(1, "Person1"),
                    new Person(2, "Person2"),
                    new Person(3, "Person3"),

                },
                3),
                new TestCaseData(
                    new Person[]
                {
                },
                0),
                new TestCaseData(
                     new Person[]
               {
                new Person(1, "Person1"),
                new Person(2, "Person2"),
                new Person(3, "Person3"),
                new Person(4, "Person4"),
                new Person(5, "Person5"),
                new Person(6, "Person6"),
                new Person(7, "Person7"),
                new Person(8, "Person8"),
                new Person(9, "Person9"),
                new Person(10, "Person10"),
                new Person(11, "Person11"),
                new Person(12, "Person12"),
                new Person(13, "Person13"),
                new Person(14, "Person14"),
                new Person(15, "Person15"),
                new Person(16, "Person16"),
               },
               16)
            };

            foreach (var item in testCaseData)
            {
                yield return item;
            }
        }

    }
}