using System;
using BankApp.Identity.Domain.Shared.Events;

namespace BankApp.Identity.Core.Events.DomainEvents;

public static class DomainEventsMapper
{
    public static IEvent MapToPublicEvent(this IDomainEvent domainEvent)
    {
        return domainEvent switch
        {
            UserCreatedEvent @event => new Events.IntegrationEvents.UserCreatedEvent
            {
                UserId = @event.UserId
            },
            _ => throw new NotSupportedException($"{domainEvent.GetType().Name} cannot be mapped")
        };
    }
}