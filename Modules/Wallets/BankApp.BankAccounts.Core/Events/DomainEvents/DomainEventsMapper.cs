using System;
using BankApp.BankAccounts.Domain.Shared.Events;

namespace BankApp.Wallets.Core.Events.DomainEvents;

public static class DomainEventsMapper
{
    public static IEvent MapToPublicEvent(this IDomainEvent domainEvent)
    {
        return domainEvent switch
        {
            _ => throw new NotSupportedException($"{domainEvent.GetType().Name} cannot be mapped")
        };
    }
}