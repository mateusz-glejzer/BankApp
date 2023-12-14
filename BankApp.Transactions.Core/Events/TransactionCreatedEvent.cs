using System;

namespace BankApp.Transactions.Core.Events;

public record TransactionCreatedEvent(Guid ServiceId, Transaction Transaction) : IEvent;