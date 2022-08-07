namespace Chainblock.Tests
{
    using System;

    using NUnit.Framework;

    using Contracts;
    using Models;
    using System.Reflection;
    using System.Linq;
    using System.Collections.Generic;

    [TestFixture]
    public class ChainblockTests
    {
        private ITransaction defTransaction;
        private IChainblock chainblock;

        [SetUp]
        public void SetUp()
        {
            this.defTransaction = new Transaction(1, TransactionStatus.Successful, "Pesho", "Gosho", 100);
            this.chainblock = new Chainblock();
        }

        [Test]
        public void ChainblockShouldStoreTransactionsInPrivateCollection()
        {
            Type type = typeof(Chainblock);
            FieldInfo[] privateFields = type
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.IsPrivate)
                .ToArray();
            bool transactionCollectionExist = privateFields
                .Any(fi => fi.FieldType == typeof(ICollection<ITransaction>));

            Assert.IsTrue(transactionCollectionExist);
        }

        [Test]
        public void ConstructorShouldInitializeCollectionAndCountProperty()
        {
            Type type = typeof(Chainblock);
            FieldInfo collectionField = type
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.IsPrivate &&
                f.FieldType == typeof(ICollection<ITransaction>));

            IChainblock chainblockTest = new Chainblock();

            object actualFieldValue = collectionField.GetValue(chainblockTest);
            int actualCount = chainblockTest.Count;
            int expectedCount = 0;

            Assert.IsNotNull(actualFieldValue);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddingTransactionShouldPhisicalyAddTheTransaction()
        {
            ITransaction transactionToAdd = new Transaction(2, TransactionStatus.Successful, "Pesho", "Gosho", 39);

            this.chainblock.Add(transactionToAdd);

            Type type = typeof(Chainblock);
            FieldInfo collectionField = type
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.IsPrivate &&
                f.FieldType == typeof(ICollection<ITransaction>));

            ICollection<ITransaction> actualFieldValue = (ICollection<ITransaction>)collectionField.GetValue(this.chainblock);

            bool addedTransactionExist = this.chainblock.Contains(transactionToAdd);

            Assert.IsTrue(addedTransactionExist);
        }

        [Test]
        public void AddingTransactionShouldIncreaseCount()
        {
            this.chainblock.Add(this.defTransaction);
            int actualCount = this.chainblock.Count;
            int expectedCount = 1;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddingExistingTransactionShouldThrowAnException()
        {
            this.chainblock.Add(this.defTransaction);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.Add(this.defTransaction);
            }, "You cannot add already existing transaction!");
        }

        [Test]
        public void ContainsByTransactionShouldReturnTrueWithExistingTransaction()
        {
            this.chainblock.Add(this.defTransaction);
            bool transactionContains = this.chainblock.Contains(this.defTransaction);

            Assert.IsTrue(transactionContains);
        }

        [Test]
        public void ContainsByTransactionShouldReturnFalseWithNonExistingTransaction()
        {
            this.chainblock.Add(this.defTransaction);
            ITransaction nonExistingTransaction = new Transaction(3, TransactionStatus.Successful, "dddd", "dddq", 33);
            bool transactionContains = this.chainblock.Contains(nonExistingTransaction);

            Assert.IsFalse(transactionContains);
        }

        [Test]
        public void ContainsByIdShouldReturnTrueWithExistingTransaction()
        {
            this.chainblock.Add(this.defTransaction);

            bool transactionContains = this.chainblock.Contains(1);

            Assert.IsTrue(transactionContains);
        }

        [Test]
        public void ContainsByIdShouldReturnFalseWithNonExistingTransaction()
        {
            bool actualResult = this.chainblock.Contains(this.defTransaction.Id);
            Assert.IsFalse(actualResult);
        }

        [Test]
        public void ChangeTransactionStatusShouldChangeTheStatusValueWhenSuccess()
        {
            ITransaction transaction = new Transaction(2, TransactionStatus.Failed, "Pesho", "Gosho", 50);
            this.chainblock.Add(transaction);

            this.chainblock.ChangeTransactionStatus(2, TransactionStatus.Successful);

            TransactionStatus expectedStatus = TransactionStatus.Successful;
            TransactionStatus actualStatus = transaction.Status;

            Assert.AreEqual(expectedStatus, actualStatus);
        }

        [Test]
        public void ChangeTransactionStatusShouldThrowAnExceptionWithNonExistingTransaction()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.chainblock.ChangeTransactionStatus(7, TransactionStatus.Successful);
            }, "You cannot change the status of non-existing transaction!");
        }

        [Test]
        public void RemoveTransactionShouldPhisicalyRemoveTheTransaction()
        {
            ITransaction transactionToRemove = new Transaction(2, TransactionStatus.Successful, "Pesho", "Gosho", 39);

            this.chainblock.Add(transactionToRemove);

            this.chainblock.RemoveTransactionById(transactionToRemove.Id);

            Type type = typeof(Chainblock);
            FieldInfo collectionField = type
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.IsPrivate &&
                f.FieldType == typeof(ICollection<ITransaction>));

            ICollection<ITransaction> actualFieldValue = (ICollection<ITransaction>)collectionField.GetValue(this.chainblock);

            bool removeTransactionDoesNotExist = this.chainblock.Contains(transactionToRemove);

            Assert.IsFalse(removeTransactionDoesNotExist);
        }

        [Test]
        public void RemoveTransactionShouldDecreaseCount()
        {
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Successful, "Pesho", "Gosho", 39);
            this.chainblock.Add(this.defTransaction);
            this.chainblock.Add(transaction2);

            this.chainblock.RemoveTransactionById(transaction2.Id);

            int actualCount = this.chainblock.Count;
            int expectedCount = 1;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemoveNonExistingTransactionShouldThrowAnException()
        {
            this.chainblock.Add(this.defTransaction);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.RemoveTransactionById(7);
            }, "You cannot remove transaction because the ID does not exist!");
        }

        [Test]
        public void GetByIdShouldReturnTransactionWithExistingId()
        {
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Successful, "Pesho", "Gosho", 39);

            this.chainblock.Add(this.defTransaction);
            this.chainblock.Add(transaction2);

            ITransaction defTranscationRef = this.chainblock.GetById(this.defTransaction.Id);

            int expectedId = this.defTransaction.Id;
            int actualId = defTranscationRef.Id;

            Assert.AreEqual(expectedId, actualId);
        }

        [Test]
        public void GetByIdShouldThrowExceptionWithNonExistingId()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetById(7);
            }, "The Id does not exixst!");
        }

        [Test]
        public void GetByTransactionStatusShouldReturnTransactionsOrderedByAmount()
        {
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Successful, "Pesho", "Gosho", 39);
            ITransaction transaction3 = new Transaction(5, TransactionStatus.Aborted, "Pesho", "Gosho", 39);

            this.chainblock.Add(transaction3);
            this.chainblock.Add(transaction2);
            this.chainblock.Add(this.defTransaction);

            ICollection<ITransaction> expectedCollection = new List<ITransaction>()
            {
                this.defTransaction,
                transaction2,
            };

            IEnumerable<ITransaction> defTranscationRef = this.chainblock.GetByTransactionStatus(TransactionStatus.Successful);

            CollectionAssert.AreEqual(expectedCollection, defTranscationRef);
        }

        [Test]
        public void GetByTransactionStatusShouldReturnSingleTransactionWhenOneTransactionMeetsTheStatus()
        {
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Failed, "Pesho", "Gosho", 39);
            ITransaction transaction3 = new Transaction(5, TransactionStatus.Aborted, "Pesho", "Gosho", 39);

            this.chainblock.Add(transaction3);
            this.chainblock.Add(transaction2);
            this.chainblock.Add(this.defTransaction);

            ICollection<ITransaction> expectedCollection = new List<ITransaction>()
            {
                this.defTransaction
            };

            IEnumerable<ITransaction> defTranscationRef = this.chainblock.GetByTransactionStatus(TransactionStatus.Successful);

            CollectionAssert.AreEqual(expectedCollection, defTranscationRef);
        }

        [Test]
        public void GetByTransactionStatusShouldThrowExceptionWhenThereAreTransactionsAndNoOneMeetsTheStatus()
        {
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Successful, "Pesho", "Gosho", 39);
            ITransaction transaction3 = new Transaction(5, TransactionStatus.Aborted, "Pesho", "Gosho", 39);

            this.chainblock.Add(transaction3);
            this.chainblock.Add(transaction2);
            this.chainblock.Add(this.defTransaction);

            Assert.Throws<InvalidOperationException>(() =>
            {
                IEnumerable<ITransaction> defTranscationRef = this.chainblock.GetByTransactionStatus(TransactionStatus.Failed);
            }, "There are no transactions in our records meeting your desired transaction status!");

        }

        [Test]
        public void GetAllSendersWithTransactionStatusShouldReturnSendersOrderedByAmount()
        {
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Successful, "Pesho", "Gosho", 40);
            ITransaction transaction3 = new Transaction(5, TransactionStatus.Successful, "Mimi", "Gosho", 39);
            ITransaction transaction4 = new Transaction(6, TransactionStatus.Aborted, "Gosho", "Gosho", 90);


            this.chainblock.Add(transaction3);
            this.chainblock.Add(transaction2);
            this.chainblock.Add(transaction4);
            this.chainblock.Add(this.defTransaction);

            IEnumerable<string> expectedCollection = new List<string>()
            {
                this.defTransaction.From,
                transaction2.From,
                transaction3.From
            };

            IEnumerable<string> defTranscationRef = this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successful);

            CollectionAssert.AreEqual(expectedCollection, defTranscationRef);
        }

        [Test]
        public void GetAllSendersWithTransactionStatusShouldThrowExceptionWithNonExistingStatus()
        {
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Successful, "Pesho", "Gosho", 39);
            ITransaction transaction3 = new Transaction(5, TransactionStatus.Aborted, "Pesho", "Gosho", 39);

            this.chainblock.Add(transaction3);
            this.chainblock.Add(transaction2);
            this.chainblock.Add(this.defTransaction);

            Assert.Throws<InvalidOperationException>(() =>
            {
                IEnumerable<string> defTranscationRef = this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Failed);
            }, "There are no transactions in our records meeting your desired transaction status!");

        }


        [Test]
        public void GetAllReceiversWithTransactionStatusShouldReturnSendersOrderedByAmount()
        {
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Successful, "Pesho", "Gosho", 40);
            ITransaction transaction3 = new Transaction(5, TransactionStatus.Successful, "Mimi", "Mimi", 39);
            ITransaction transaction4 = new Transaction(6, TransactionStatus.Aborted, "Gosho", "Gosho", 90);


            this.chainblock.Add(transaction3);
            this.chainblock.Add(transaction2);
            this.chainblock.Add(transaction4);
            this.chainblock.Add(this.defTransaction);

            IEnumerable<string> expectedCollection = new List<string>()
            {
                this.defTransaction.To,
                transaction2.To,
                transaction3.To
            };

            IEnumerable<string> defTranscationRef = this.chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successful);

            CollectionAssert.AreEqual(expectedCollection, defTranscationRef);
        }

        [Test]
        public void GetAllReceiversWithTransactionStatusShouldThrowExceptionWithNonExistingStatus()
        {
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Successful, "Pesho", "Mimi", 39);
            ITransaction transaction3 = new Transaction(5, TransactionStatus.Aborted, "Pesho", "Pesho", 39);

            this.chainblock.Add(transaction3);
            this.chainblock.Add(transaction2);
            this.chainblock.Add(this.defTransaction);

            Assert.Throws<InvalidOperationException>(() =>
            {
                IEnumerable<string> defTranscationRef = this.chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Failed);
            }, "There are no transactions in our records meeting your desired transaction status!");

        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenByIdShouldReturnTransactionsSuccessfully()
        {
            ITransaction transaction2 = new Transaction(6, TransactionStatus.Successful, "Pesho", "Gosho", 39);
            ITransaction transaction3 = new Transaction(5, TransactionStatus.Aborted, "Mimi", "Gosho", 39);

            this.chainblock.Add(transaction3);
            this.chainblock.Add(transaction2);
            this.chainblock.Add(this.defTransaction);

            ICollection<ITransaction> expectedCollection = new List<ITransaction>()
            {
                this.defTransaction,
                transaction3,
                transaction2
            };

            IEnumerable<ITransaction> defTranscationRef = this.chainblock.GetAllOrderedByAmountDescendingThenById();

            CollectionAssert.AreEqual(expectedCollection, defTranscationRef);
        }


        [Test]
        public void GetAllOrderedByAmountDescThenByIdShouldReturnCorrectOrderWithSingleElement()
        {
            this.chainblock.Add(this.defTransaction);

            ICollection<ITransaction> expectedCollection = new List<ITransaction>()
            {
                this.defTransaction
            };

            IEnumerable<ITransaction> defTranscationRef = this.chainblock.GetAllOrderedByAmountDescendingThenById();

            CollectionAssert.AreEqual(expectedCollection, defTranscationRef);

        }

        [Test]
        public void GetBySenderOrderedByAmountDescendingShouldReturnTransactionsSuccessfully()
        {
            ITransaction transaction2 = new Transaction(6, TransactionStatus.Successful, "Pesho", "Gosho", 4);
            ITransaction transaction3 = new Transaction(5, TransactionStatus.Aborted, "Mimi", "Gosho", 50);
            ITransaction transaction4 = new Transaction(7, TransactionStatus.Aborted, "Mini", "Gosho", 80);


            this.chainblock.Add(transaction3);
            this.chainblock.Add(transaction4);
            this.chainblock.Add(transaction2);
            this.chainblock.Add(this.defTransaction);

            ICollection<ITransaction> expectedCollection = new List<ITransaction>()
            {
                this.defTransaction,
                transaction2
            };

            IEnumerable<ITransaction> defTranscationRef = this.chainblock.GetBySenderOrderedByAmountDescending("Pesho");

            CollectionAssert.AreEqual(expectedCollection, defTranscationRef);
        }

        [Test]
        public void GetBySenderOrderedByAmountDescendingShouldThrowExceptionWithNonExistingSender()
        {
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Successful, "Pesho", "Mimi", 39);
            ITransaction transaction3 = new Transaction(5, TransactionStatus.Aborted, "Mimi", "Pesho", 69);

            this.chainblock.Add(transaction3);
            this.chainblock.Add(transaction2);
            this.chainblock.Add(this.defTransaction);

            Assert.Throws<InvalidOperationException>(() =>
            {
                IEnumerable<ITransaction> defTranscationRef = this.chainblock.GetBySenderOrderedByAmountDescending("Gosho");
            }, "There are no transactions in our records meeting your desired transaction sender!");

        }


        [Test]
        public void GetByReceiveOrderedByAmountThenBuIdShouldReturnTransactionsSuccessfully()
        {
            ITransaction transaction2 = new Transaction(6, TransactionStatus.Successful, "Pesho", "Gosho", 100);
            ITransaction transaction3 = new Transaction(5, TransactionStatus.Aborted, "Mimi", "Mibi", 50);
            ITransaction transaction4 = new Transaction(7, TransactionStatus.Aborted, "Mini", "Gosho", 109);


            this.chainblock.Add(transaction3);
            this.chainblock.Add(transaction2);
            this.chainblock.Add(transaction4);
            this.chainblock.Add(this.defTransaction);

            ICollection<ITransaction> expectedCollection = new List<ITransaction>()
            {
                transaction4,
                this.defTransaction,
                transaction2
            };

            IEnumerable<ITransaction> defTranscationRef = this.chainblock.GetByReceiverOrderedByAmountThenById("Gosho");

            CollectionAssert.AreEqual(expectedCollection, defTranscationRef);
        }

        [Test]
        public void GetByReceiveOrderedByAmountThenBuIdShouldThrowExceptionWithNonExistingReceiver()
        {
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Successful, "Pesho", "Mimi", 39);
            ITransaction transaction3 = new Transaction(5, TransactionStatus.Aborted, "Mimi", "Pesho", 69);

            this.chainblock.Add(transaction3);
            this.chainblock.Add(transaction2);
            this.chainblock.Add(this.defTransaction);

            Assert.Throws<InvalidOperationException>(() =>
            {
                IEnumerable<ITransaction> defTranscationRef = this.chainblock.GetByReceiverOrderedByAmountThenById("Goshko");
            }, "There are no transactions in our records meeting your desired transaction receiver!");

        }

        [Test]
        public void ShouldReturnTransactionsSuccessfully()
        {
            ITransaction transaction3 = new Transaction(5, TransactionStatus.Successful, "Mimi", "Mibi", 50);
            ITransaction transaction4 = new Transaction(7, TransactionStatus.Failed, "Mini", "Gosho", 109);
            ITransaction transaction2 = new Transaction(6, TransactionStatus.Successful, "Pesho", "Gosho", 99);


            this.chainblock.Add(transaction3);
            this.chainblock.Add(transaction2);
            this.chainblock.Add(transaction4);
            this.chainblock.Add(this.defTransaction);

            ICollection<ITransaction> expectedCollection = new List<ITransaction>()
            {
                this.defTransaction,
                transaction2,
                transaction3
            };

            IEnumerable<ITransaction> defTranscationRef = this.chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successful, 151);

            CollectionAssert.AreEqual(expectedCollection, defTranscationRef);
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmountShouldReturnEmptyCollectionWhenNoTransactionsFound()
        {
            ITransaction transaction3 = new Transaction(5, TransactionStatus.Successful, "Mimi", "Mibi", 50);
            ITransaction transaction4 = new Transaction(7, TransactionStatus.Failed, "Mini", "Gosho", 109);
            ITransaction transaction2 = new Transaction(6, TransactionStatus.Successful, "Pesho", "Gosho", 100);


            this.chainblock.Add(transaction3);
            this.chainblock.Add(transaction2);
            this.chainblock.Add(transaction4);
            this.chainblock.Add(this.defTransaction);

            ICollection<ITransaction> expectedCollection = new List<ITransaction>()
            {
            };

            IEnumerable<ITransaction> defTranscationRef = this.chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Unauthorized, 151);

            CollectionAssert.AreEqual(expectedCollection, defTranscationRef);
        }

        [Test]
        public void GetBySenderAndMinimumtDescendingShouldReturnTransactionsSuccessfully()
        {
            ITransaction transaction3 = new Transaction(5, TransactionStatus.Successful, "Pesho", "Mibi", 90);
            ITransaction transaction4 = new Transaction(7, TransactionStatus.Failed, "Mini", "Gosho", 109);
            ITransaction transaction2 = new Transaction(6, TransactionStatus.Successful, "Pesho", "Gosho", 3);


            this.chainblock.Add(transaction3);
            this.chainblock.Add(transaction2);
            this.chainblock.Add(transaction4);
            this.chainblock.Add(this.defTransaction);

            ICollection<ITransaction> expectedCollection = new List<ITransaction>()
            {
                this.defTransaction,
                transaction3
            };

            IEnumerable<ITransaction> defTranscationRef = this.chainblock.GetBySenderAndMinimumAmountDescending("Pesho", 89);

            CollectionAssert.AreEqual(expectedCollection, defTranscationRef);
        }

        [Test]
        public void GetBySenderAndMinimumtDescendingShouldThrowExceptionIfSuchSenderNotExist()
        {
            ITransaction transaction3 = new Transaction(5, TransactionStatus.Successful, "Mimi", "Mibi", 50);
            ITransaction transaction4 = new Transaction(7, TransactionStatus.Failed, "Mini", "Gosho", 109);
            ITransaction transaction2 = new Transaction(6, TransactionStatus.Successful, "Pesho", "Gosho", 100);


            this.chainblock.Add(transaction3);
            this.chainblock.Add(transaction2);
            this.chainblock.Add(transaction4);
            this.chainblock.Add(this.defTransaction);

            Assert.Throws<InvalidOperationException>(() =>
            {
                IEnumerable<ITransaction> defTranscationRef = this.chainblock.GetBySenderAndMinimumAmountDescending("Goshko", 9);
            }, "There are no transactions in our records meeting your desired transaction sender!");
        }


        [Test]
        public void GetBySenderAndMinimumtDescendingShouldThrowExceptionIfSuchTransactionAmountNotExist()
        {
            ITransaction transaction3 = new Transaction(5, TransactionStatus.Successful, "Mimi", "Mibi", 50);
            ITransaction transaction4 = new Transaction(7, TransactionStatus.Failed, "Mini", "Gosho", 109);
            ITransaction transaction2 = new Transaction(6, TransactionStatus.Successful, "Pesho", "Gosho", 139);


            this.chainblock.Add(transaction3);
            this.chainblock.Add(transaction2);
            this.chainblock.Add(transaction4);
            this.chainblock.Add(this.defTransaction);

            Assert.Throws<InvalidOperationException>(() =>
            {
                IEnumerable<ITransaction> defTranscationRef = this.chainblock.GetBySenderAndMinimumAmountDescending("Pesho", 139);
            }, "There are no transactions in our records meeting your desired transaction amount!");
        }

        [Test]
        public void GetByReceiverAndAmountRangeShouldReturnTransactionsOrderedByAmountThenByIdSuccessfully()
        {
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Successful, "Pesho", "Gosho", 60);
            ITransaction transaction3 = new Transaction(3, TransactionStatus.Aborted, "Mimi", "Mibi", 50);
            ITransaction transaction4 = new Transaction(4, TransactionStatus.Aborted, "Mini", "Gosho", 100);
            ITransaction transaction5 = new Transaction(5, TransactionStatus.Aborted, "Mini", "Gosho", 101);
            ITransaction transaction6 = new Transaction(6, TransactionStatus.Aborted, "Mini", "Gosho", 60);
            ITransaction transaction7 = new Transaction(7, TransactionStatus.Aborted, "Mimi", "Gosho", 59);




            this.chainblock.Add(transaction3);
            this.chainblock.Add(transaction2);
            this.chainblock.Add(transaction4);
            this.chainblock.Add(transaction5);
            this.chainblock.Add(transaction6);
            this.chainblock.Add(transaction7);
            this.chainblock.Add(this.defTransaction);

            ICollection<ITransaction> expectedCollection = new List<ITransaction>()
            {
                this.defTransaction,
                transaction4,
                transaction2,
                transaction6,
            };

            IEnumerable<ITransaction> defTranscationRef = this.chainblock.GetByReceiverAndAmountRange("Gosho", 60, 101);

            CollectionAssert.AreEqual(expectedCollection, defTranscationRef);
        }

        [Test]
        public void GetByReceiverAndAmountRangeShouldReturnThrowExceptionWithNonExistingReceiver()
        {
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Successful, "Pesho", "Mimi", 39);
            ITransaction transaction3 = new Transaction(5, TransactionStatus.Aborted, "Mimi", "Pesho", 69);

            this.chainblock.Add(transaction3);
            this.chainblock.Add(transaction2);
            this.chainblock.Add(this.defTransaction);

            Assert.Throws<InvalidOperationException>(() =>
            {
                IEnumerable<ITransaction> defTranscationRef = this.chainblock.GetByReceiverAndAmountRange("Goshko", 60, 101);
            }, "There are no transactions in our records meeting your desired transaction receiver!");
        }

        [Test]
        public void GetByReceiverAndAmountRangeShouldReturnThrowExceptionWithNonExistingAmountRange()
        {
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Successful, "Pesho", "Gosho", 60);
            ITransaction transaction3 = new Transaction(3, TransactionStatus.Aborted, "Mimi", "Mibi", 50);
            ITransaction transaction4 = new Transaction(4, TransactionStatus.Aborted, "Mini", "Gosho", 100);
            ITransaction transaction5 = new Transaction(5, TransactionStatus.Aborted, "Mini", "Gosho", 101);
            ITransaction transaction6 = new Transaction(6, TransactionStatus.Aborted, "Mini", "Gosho", 60);
            ITransaction transaction7 = new Transaction(7, TransactionStatus.Aborted, "Mimi", "Gosho", 59);

            this.chainblock.Add(transaction3);
            this.chainblock.Add(transaction2);
            this.chainblock.Add(transaction4);
            this.chainblock.Add(transaction5);
            this.chainblock.Add(transaction6);
            this.chainblock.Add(transaction7);
            this.chainblock.Add(this.defTransaction);

            Assert.Throws<InvalidOperationException>(() =>
            {
                IEnumerable<ITransaction> defTranscationRef = this.chainblock.GetByReceiverAndAmountRange("Gosho", 1, 59);
            }, "There are no transactions in our records meeting your desired transaction amount range!");
        }


        [Test]
        public void GetAllInAmountRangeShouldReturnTransactionsOrderedByInsertion()
        {
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Successful, "Pesho", "Gosho", 60);
            ITransaction transaction3 = new Transaction(3, TransactionStatus.Aborted, "Mimi", "Mibi", 50);
            ITransaction transaction4 = new Transaction(4, TransactionStatus.Aborted, "Mini", "Gosho", 100);
            ITransaction transaction5 = new Transaction(5, TransactionStatus.Aborted, "Mini", "Gosho", 101);
            ITransaction transaction6 = new Transaction(6, TransactionStatus.Aborted, "Mini", "Gosho", 60);
            ITransaction transaction7 = new Transaction(7, TransactionStatus.Aborted, "Mimi", "Gosho", 59);

            this.chainblock.Add(this.defTransaction);
            this.chainblock.Add(transaction2);
            this.chainblock.Add(transaction3);
            this.chainblock.Add(transaction4);
            this.chainblock.Add(transaction5);
            this.chainblock.Add(transaction6);
            this.chainblock.Add(transaction7);

            ICollection<ITransaction> expectedCollection = new List<ITransaction>()
            {
                this.defTransaction,
                transaction2,
                transaction4,
                transaction5,
                transaction6,
                transaction7,
            };

            IEnumerable<ITransaction> defTranscationRef = this.chainblock.GetAllInAmountRange(59, 101);

            CollectionAssert.AreEqual(expectedCollection, defTranscationRef);
        }


        [Test]
        public void GetAllInAmountRangeShouldReturnEmptyCollectionWhenNoTransactionsFound()
        {
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Successful, "Pesho", "Gosho", 60);
            ITransaction transaction3 = new Transaction(3, TransactionStatus.Aborted, "Mimi", "Mibi", 50);
            ITransaction transaction4 = new Transaction(4, TransactionStatus.Aborted, "Mini", "Gosho", 100);
            ITransaction transaction5 = new Transaction(5, TransactionStatus.Aborted, "Mini", "Gosho", 101);
            ITransaction transaction6 = new Transaction(6, TransactionStatus.Aborted, "Mini", "Gosho", 60);
            ITransaction transaction7 = new Transaction(7, TransactionStatus.Aborted, "Mimi", "Gosho", 59);

            this.chainblock.Add(this.defTransaction);
            this.chainblock.Add(transaction2);
            this.chainblock.Add(transaction3);
            this.chainblock.Add(transaction4);
            this.chainblock.Add(transaction5);
            this.chainblock.Add(transaction6);
            this.chainblock.Add(transaction7);

            ICollection<ITransaction> expectedCollection = new List<ITransaction>()
            {
            };
            IEnumerable<ITransaction> defTranscationRef = this.chainblock.GetAllInAmountRange(102, 200);

            CollectionAssert.AreEqual(expectedCollection, defTranscationRef);
        }

        [Test]
        public void ChainblockShouldBeIterable()
        {
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Successful, "Pesho", "Gosho", 60);
            ITransaction transaction3 = new Transaction(3, TransactionStatus.Aborted, "Mimi", "Mibi", 50);
            ITransaction transaction4 = new Transaction(4, TransactionStatus.Aborted, "Mini", "Gosho", 100);
            ITransaction transaction5 = new Transaction(5, TransactionStatus.Aborted, "Mini", "Gosho", 101);
            ITransaction transaction6 = new Transaction(6, TransactionStatus.Aborted, "Mini", "Gosho", 60);
            ITransaction transaction7 = new Transaction(7, TransactionStatus.Aborted, "Mimi", "Gosho", 59);

            this.chainblock.Add(this.defTransaction);
            this.chainblock.Add(transaction2);
            this.chainblock.Add(transaction3);
            this.chainblock.Add(transaction4);
            this.chainblock.Add(transaction5);
            this.chainblock.Add(transaction6);
            this.chainblock.Add(transaction7);

            ICollection<ITransaction> actualIteration = new List<ITransaction>();

            foreach (var transaction in this.chainblock)
            {
                actualIteration.Add(transaction);
            }

            ICollection<ITransaction> expectedItteration = new List<ITransaction>()
            {

                this.defTransaction,
                transaction2,
                transaction3,
                transaction4,
                transaction5,
                transaction6,
                transaction7,
            };

            CollectionAssert.AreEqual(expectedItteration, actualIteration);
        }
    }
}
