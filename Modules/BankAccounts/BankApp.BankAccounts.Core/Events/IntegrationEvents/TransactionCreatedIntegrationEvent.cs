using BankApp.BankAccounts.Domain.Transactions;

namespace BankApp.Wallets.Core.Events.IntegrationEvents;

public record TransactionCreatedIntegrationEvent(Transaction Transaction) : IEvent;