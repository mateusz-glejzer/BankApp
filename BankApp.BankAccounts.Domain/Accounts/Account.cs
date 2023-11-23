using System;
using System.Collections.Generic;
using System.Transactions;
using BankApp.BankAccounts.Domain.Shared;
using BankApp.BankAccounts.Domain.Shared.DomainEvents;

namespace BankApp.BankAccounts.Domain.Accounts;

public class Account : DomainEventsSource
{
    private List<Transaction> Transactions { get; set; }
    private UserId UserId { get; init; }
    private AccountId AccountId { get; init; }
    private Currency Currency { get; init; }
    private AccountState AccountState { get; init; }

    public Account(UserId userId, Currency currency, AccountId accountId = default)
    {
        Transactions = new List<Transaction>();
        UserId = userId;
        Currency = currency;
        AccountId = accountId ?? new Guid();
        AccountState = AccountState.Active;
    }

    public void BlockAccount()
    {
    }

    public void UnblockAccount()
    {
    }

    public void CreateTransaction()
    {
        _domainEvents.Enqueue();
    }

    public void OnReceivedTransaction(Transaction transaction)
    {
        Transactions.Add(transaction);
    }
}