using System.Transactions;

namespace BankApp.Wallets.Core.Events.IntegrationEvents;

public record TransactionCreatedIntegrationEvent(Transaction Transaction) : IEvent;