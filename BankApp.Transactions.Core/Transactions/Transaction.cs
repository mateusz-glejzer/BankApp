using System;
using BankApp.Transactions.Core.Shared;

namespace BankApp.Transactions.Core.Transactions;

public class Transaction
{
    public Transaction(AccountId recipientAccountId, AccountId senderAccountId, double amount, Currency currency,
        DateTime? date = null)
    {
        RecipientAccountId = recipientAccountId;
        SenderAccountId = senderAccountId;
        Amount = amount;
        Currency = currency;
        TransactionId = new Guid();
        Date = date ?? DateTime.UtcNow;
    }

    private Transaction(AccountId recipientAccountId, AccountId senderAccountId, double amount, Currency currency, TransactionId transactionId,
        DateTime date)
    {
        RecipientAccountId = recipientAccountId;
        SenderAccountId = senderAccountId;
        Amount = amount;
        Currency = currency;
        TransactionId = transactionId;
        Date = date;
    }

    public TransactionId TransactionId { get; init; }
    public AccountId RecipientAccountId { get; init; }
    public AccountId SenderAccountId { get; init; }
    public double Amount { get; init; }
    public Currency Currency { get; init; }
    public DateTime Date { get; init; }
}