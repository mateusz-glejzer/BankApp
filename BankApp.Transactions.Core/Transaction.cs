using System;
using BankApp.Transactions.Core.Shared;

namespace BankApp.Transactions.Core;

public class Transaction
{
    public Transaction(UserId recipient, UserId sender, double amount, Currency currency,
        DateTime? date = null)
    {
        Recipient = recipient;
        Sender = sender;
        Amount = amount;
        Currency = currency;
        TransactionId = new Guid();
        Date = date ?? DateTime.UtcNow;
    }

    public TransactionId TransactionId { get; init; }
    public UserId Recipient { get; init; }
    public UserId Sender { get; init; }
    public double Amount { get; init; }
    public Currency Currency { get; init; }
    public DateTime Date { get; init; }
}