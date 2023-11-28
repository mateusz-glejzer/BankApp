using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BankApp.Wallets.Core.Events;

namespace BankApp.Wallets.Core.Extensions;

public static class EventDispatcherExtensions
{
    public static Task PublishMultiple(this IEventDispatcher eventDispatcher, IEnumerable<IEvent> domainEvents,
        CancellationToken cancellationToken = default)
    {
        var publishEventTasks = domainEvents
            .Select(@event => eventDispatcher.PublishAsync(@event, cancellationToken));
        return Task.WhenAll(publishEventTasks);
    }
}