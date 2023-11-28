using System;
using BankApp.BankAccounts.Domain.Shared;

namespace BankApp.BankAccounts.Domain.Transactions;

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

    private Guid TransactionId { get; init; }
    private UserId Recipient { get; init; }
    private UserId Sender { get; init; }
    private double Amount { get; init; }
    private Currency Currency { get; init; }
    private DateTime Date { get; init; }
}