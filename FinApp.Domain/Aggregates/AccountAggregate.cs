using FinApp.Domain.Entities;
using FinApp.Domain.Enums;
using FinApp.Domain.Exceptions;
using FinApp.Domain.Interfaces;
using FinApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Domain.Aggregates
{
    public class AccountAggregate : IAggregateRoot
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public AccountType AccountType { get; private set; }
        public Balance Balance { get; private set; }
        public int UserId { get; private set; }
        private readonly List<Transaction> _transactions;
        private readonly IReadOnlyCollection<Transaction> _transactionsReadOnly;
        public IReadOnlyCollection<Transaction> Transactions
        {
            get { return _transactionsReadOnly; }
        }

        public AccountAggregate(string name, AccountType accountType, double balance, int userId, List<Transaction> transactions)
        {
            Name = name;
            AccountType = accountType;
            Balance = Balance.Create(balance);
            UserId = userId;
            _transactions = transactions != null ? new List<Transaction>(transactions) : new List<Transaction>();
            _transactionsReadOnly = _transactions.AsReadOnly();
        }

        public void AddTransaction(Transaction transaction)
        {
            if (transaction == null) throw new DomainException("Transactions cannot be empty.");

            if (transaction.Amount.Value <= 0)
                throw new DomainException("Transaction amount must be positive.");

            _transactions.Add(transaction);
        }

        public void Withdrawal(double value, string title, string description, int accountId, List<int> categoryIds)
        {
            if (value <= 0)
                throw new DomainException("Withdrawal amount must be positive.");

            Balance = Balance.Subtract(value);
            var categoryTransactions = categoryIds
                .Select(id => new CategoryTransaction(id))
                .ToList();
            var transaction = new Transaction(
                title,
                description,
                value,
                TransactionType.Deposit,
                accountId,
                categoryTransactions
            );

            AddTransaction(transaction);
        }

        public void Deposit(double value, string title, string description, int accountId, List<int> categoryIds)
        {
            if (value <= 0)
                throw new DomainException("Deposit amount must be positive.");

            Balance = Balance.Add(value);

            var categoryTransactions = categoryIds
            .Select(id => new CategoryTransaction(id))
            .ToList();

            var transaction = new Transaction(
                title,
                description,
                value,
                TransactionType.Deposit,
                accountId,
                categoryTransactions
            );

            AddTransaction(transaction);
        }
    }
}
