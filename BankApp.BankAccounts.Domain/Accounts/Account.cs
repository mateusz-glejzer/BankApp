using System;
using BankApp.BankAccounts.Domain.Accounts.Exceptions;
using BankApp.BankAccounts.Domain.Shared;
using BankApp.BankAccounts.Domain.Shared.Events;
using BankApp.BankAccounts.Domain.Transactions;

namespace BankApp.BankAccounts.Domain.Accounts;

public class Account : DomainEventsSource
{
    private AccountId AccountId { get; init; }
    private UserId UserId { get; init; }
    private Currency Currency { get; init; }
    private AccountState AccountState { get; set; }

    public Account(UserId userId, Currency currency, AccountId accountId = default)
    {
        UserId = userId;
        Currency = currency;
        AccountId = accountId ?? new Guid();
        AccountState = AccountState.Active;
    }

    public void BlockAccount()
    {
        AccountState = AccountState.Blocked;
    }

    public void UnblockAccount()
    {
        AccountState = AccountState.Active;
    }

    public void CreateTransaction(UserId recipient, double amount)
    {
        if (AccountState is AccountState.Blocked)
        {
            throw new AccountIsBlockedException();
        }

        if (double.IsNegative(amount))
        {
            throw new TransactionAmountIsNotPositiveNumberException();
        }

        _domainEvents.Enqueue(
            new TransactionCreatedEvent(new Transaction(recipient, UserId, amount, Currency)));
    }
}