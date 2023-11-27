using BankApp.BankAccounts.Domain.Shared.DomainEvents;
using BankApp.BankAccounts.Domain.Transactions;

namespace BankApp.BankAccounts.Domain.Shared.Events;

public record TransactionCreatedEvent(Transaction Transaction) : IDomainEvent;