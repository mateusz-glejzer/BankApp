﻿using System;
using BankApp.BankAccounts.Domain.Accounts.Exceptions;
using BankApp.BankAccounts.Domain.Shared;
using BankApp.BankAccounts.Domain.Shared.Events;
using BankApp.BankAccounts.Domain.Transactions;

namespace BankApp.BankAccounts.Domain.Accounts;

public class Account : DomainEventsSource
{
    public AccountId AccountId { get; private set; }
    public UserId UserId { get; private set; }
    public Currency Currency { get; private set; }
    public AccountState AccountState { get; private set; }

    public Account(UserId userId, Currency currency)
    {
        UserId = userId;
        Currency = currency;
        AccountState = AccountState.Active;
        AccountId = Guid.NewGuid();
    }

    public void BlockAccount()
    {
        AccountState = AccountState.Blocked;

        _domainEvents.Enqueue(new AccountBlockedDomainEvent(this));
    }

    public void UnblockAccount()
    {
        AccountState = AccountState.Active;
        _domainEvents.Enqueue(new AccountUnblockedDomainEvent(this));
    }

    public void CreateTransaction(AccountId recipientAccountId, double amount)
    {
        if (AccountState is AccountState.Blocked)
        {
            throw new AccountIsBlockedException();
        }

        if (double.IsNegative(amount))
        {
            throw new TransactionAmountIsNotPositiveNumberException();
        }

        var transaction = new Transaction(recipientAccountId, AccountId, amount, Currency);
        _domainEvents.Enqueue(
            new TransactionCreatedDomainEvent(AccountId, transaction));
    }
}