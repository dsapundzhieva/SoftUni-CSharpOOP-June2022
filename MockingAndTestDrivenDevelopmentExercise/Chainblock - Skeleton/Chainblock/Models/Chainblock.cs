using Chainblock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Chainblock.Models
{
    public class Chainblock : IChainblock
    {
        private readonly ICollection<ITransaction> transactions;

        public Chainblock()
        {
            this.transactions = new HashSet<ITransaction>();
        }
        public int Count => this.transactions.Count;

        public void Add(ITransaction tx)
        {
            if (this.Contains(tx))
            {
                throw new InvalidOperationException("You cannot add already existing transaction!");
            }
            this.transactions.Add(tx);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            ITransaction currentTransaction = this.transactions.FirstOrDefault(t => t.Id == id);

            if (currentTransaction == null)
            {
                throw new ArgumentException("You cannot change the status of non-existing transaction!");
            }
            currentTransaction.Status = newStatus;
        }

        public bool Contains(ITransaction tx)
        {
            return this.transactions.Any(t => t.Id == tx.Id);
        }

        public bool Contains(int id)
        {
            return this.transactions.Any(t => t.Id == id);
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(decimal lo, decimal hi)
        {
            IEnumerable<ITransaction> transactionsByRange = this.transactions.Where(t => t.Amount >= lo && t.Amount <= hi).ToList();

            return transactionsByRange;
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            return this.transactions.OrderByDescending(t => t.Amount).ThenBy(t => t.Id);
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            IEnumerable<string> receivers = this.transactions.Where(t => t.Status == status).OrderByDescending(t => t.Amount).Select(t => t.To).ToArray();

            if (!receivers.Any())
            {
                throw new InvalidOperationException(
                  "There are no transactions in our records meeting provided transaction status!");
            }

            return receivers;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            IEnumerable<string> senders = this.transactions.Where(t => t.Status == status).OrderByDescending(t => t.Amount).Select(t => t.From).ToArray();

            if (!senders.Any())
            {
                throw new InvalidOperationException(
                  "There are no transactions in our records meeting provided transaction status!");
            }

            return senders;
        }

        public ITransaction GetById(int id)
        {
            ITransaction trasnactionByID = this.transactions.FirstOrDefault(t => t.Id == id);

            if (trasnactionByID == null)
            {
                throw new InvalidOperationException("The Id does not exixst!");
            }
            return trasnactionByID;
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, decimal lo, decimal hi)
        {
            IEnumerable<ITransaction> transactionsByReceiverAndAmountRange = this.transactions
                .Where(t => t.To == receiver && t.Amount >= lo && t.Amount < hi)
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id)
                .ToList();

            if (!transactionsByReceiverAndAmountRange.Any())
            {
                throw new InvalidOperationException("There are no transactions in our records meeting your desired transaction receiver or amount range!");
            }

            return transactionsByReceiverAndAmountRange;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            IEnumerable<ITransaction> transactionsByReceiver = this.transactions.Where(t => t.To == receiver).OrderByDescending(t => t.Amount).ThenBy(t => t.Id);

            if (!transactionsByReceiver.Any())
            {
                throw new InvalidOperationException("There are no transactions in our records meeting your desired transaction receiver!");
            }
            return transactionsByReceiver;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, decimal amount)
        {
            IEnumerable<ITransaction> transactionsBySenderAndAmount = this.transactions.Where(t => t.From == sender && t.Amount > amount).OrderByDescending(t => t.Amount).ToList();

            if (!transactionsBySenderAndAmount.Any())
            {
                throw new InvalidOperationException("There are no transactions in our records meeting your desired transaction sender or amount!");
            }
            return transactionsBySenderAndAmount;
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            IEnumerable<ITransaction> transactionsBySender = this.transactions.Where(t => t.From == sender).OrderByDescending(t => t.Amount).ToList();

            if (!transactionsBySender.Any())
            {
                throw new InvalidOperationException("There are no transactions in our records meeting your desired transaction sender!");
            }

            return transactionsBySender;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
           IEnumerable<ITransaction> transactionsByStatus = this.transactions.Where(t => t.Status == status).OrderByDescending(t => t.Amount);

            if (!transactionsByStatus.Any())
            {
                throw new InvalidOperationException("There are no transactions in our records meeting your desired transaction status!");
            }

            return transactionsByStatus;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, decimal amount)
        {
            IEnumerable<ITransaction> transactionsByStatusAndMaxAmount = this.transactions
                .Where(t => t.Status == status && t.Amount <= amount).OrderByDescending(t => t.Amount).ToList();

            return transactionsByStatusAndMaxAmount;
        }

        public void RemoveTransactionById(int id)
        {
            var currentTransaction = this.transactions.FirstOrDefault(t => t.Id == id);

            if (currentTransaction == null)
            {
                throw new InvalidOperationException("You cannot remove transaction because the ID does not exist!");
            }
            this.transactions.Remove(currentTransaction);
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            foreach (var transaction in this.transactions)
            {
                yield return transaction;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
