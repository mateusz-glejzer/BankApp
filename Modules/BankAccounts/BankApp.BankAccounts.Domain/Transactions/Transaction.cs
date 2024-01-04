using System;
using BankApp.BankAccounts.Domain.Accounts;
using BankApp.BankAccounts.Domain.Shared;

namespace BankApp.BankAccounts.Domain.Transactions;

public class Transaction
{
    public Transaction(AccountId recipient, AccountId sender, double amount, Currency currency,
        DateTime? date = null)
    {
        RecipientAccountId = recipient;
        SenderAccountId = sender;
        Amount = amount;
        Currency = currency;
        TransactionId = new TransactionId(Guid.NewGuid());
        Date = date ?? DateTime.UtcNow;
    }

    public TransactionId TransactionId { get; init; }
    public AccountId RecipientAccountId { get; init; }
    public AccountId SenderAccountId { get; init; }
    public double Amount { get; init; }
    public Currency Currency { get; init; }
    public DateTime Date { get; init; }
}