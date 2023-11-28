using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BankApp.BankAccounts.Domain.Shared.Events;
using BankApp.Wallets.Core.Events;
using BankApp.Wallets.Core.Events.DomainEvents;
using BankApp.Wallets.Core.Events.IntegrationEvents;

namespace BankApp.Wallets.Core.Extensions;

public static class EventDispatcherExtensions
{
    public static Task PublishMultiple(this IDomainEventDispatcher eventDispatcher,
        IEnumerable<IDomainEvent> domainEvents,
        CancellationToken cancellationToken = default)
    {
        var publishEventTasks = domainEvents
            .Select(@event => eventDispatcher.PublishAsync(@event, cancellationToken));
        return Task.WhenAll(publishEventTasks);
    }

    public static Task PublishMultiple(this IIntegrationEventDispatcher eventDispatcher,
        IEnumerable<IEvent> domainEvents,
        CancellationToken cancellationToken = default)
    {
        var publishEventTasks = domainEvents
            .Select(@event => eventDispatcher.PublishAsync(@event, cancellationToken));
        return Task.WhenAll(publishEventTasks);
    }
}