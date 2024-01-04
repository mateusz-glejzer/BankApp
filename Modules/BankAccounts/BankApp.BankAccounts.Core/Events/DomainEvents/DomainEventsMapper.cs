using System;
using BankApp.BankAccounts.Domain.Shared.Events;
using BankApp.Wallets.Core.Events.IntegrationEvents;
using BankApp.Wallets.Core.Events.IntegrationEvents.Internal;

namespace BankApp.Wallets.Core.Events.DomainEvents;

public static class DomainEventsMapper
{
    public static IEvent MapToPublicEvent(this IDomainEvent domainEvent)
    {
        return domainEvent switch
        {
            TransactionCreatedDomainEvent @event => new TransactionCreatedIntegrationEvent(@event.AccountId,
                @event.Transaction),
            _ => throw new NotSupportedException($"{domainEvent.GetType().Name} cannot be mapped")
        };
    }
}