using BankApp.BankAccounts.Domain.Transactions;

namespace BankApp.BankAccounts.Domain.Shared.Events;

public record TransactionCreatedDomainEvent(Transaction Transaction) : IDomainEvent;