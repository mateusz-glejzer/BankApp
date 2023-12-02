using BankApp.BankAccounts.Domain.Accounts;
using BankApp.BankAccounts.Domain.Transactions;

namespace BankApp.BankAccounts.Domain.Shared.Events;

public record TransactionCreatedDomainEvent(Account Account, Transaction Transaction) : IDomainEvent;