using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BankApp.Wallets.Core.Events.EventHandlers;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.Wallets.Core.Events.Dispatcher;

public class EventDispatcher : IEventDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public EventDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task DispatchAsync(IEnumerable<IEvent> events, CancellationToken cancellationToken)
    {
        var eventList = events.ToList();
        if (eventList.Any() is false)
        {
            return;
        }

        using var scope = _serviceProvider.CreateScope();
        foreach (var @event in eventList)
        {
            var eventType = @event.GetType();
            var handlerType = typeof(IEventHandler<>).MakeGenericType(eventType);
            var handler = scope.ServiceProvider.GetRequiredService(handlerType);
            var handleAsyncMethod = handlerType.GetMethod(nameof(IEventHandler<IEvent>.HandleAsync));

            await (Task)handleAsyncMethod.Invoke(handler, new object[] { @event, cancellationToken });
        }
    }
}