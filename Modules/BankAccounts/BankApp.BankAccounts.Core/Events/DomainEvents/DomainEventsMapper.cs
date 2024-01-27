using System;
using BankApp.BankAccounts.Core.Events.IntegrationEvents.Internal;
using BankApp.BankAccounts.Domain.Shared.Events;

namespace BankApp.BankAccounts.Core.Events.DomainEvents;

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