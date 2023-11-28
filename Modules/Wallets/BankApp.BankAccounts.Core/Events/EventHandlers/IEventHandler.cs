﻿using System.Threading;
using System.Threading.Tasks;

namespace BankApp.Wallets.Core.Events.EventHandlers;

public interface IEventHandler<in TEvent> where TEvent : class, IEvent
{
    Task HandleAsync(TEvent @event, CancellationToken cancellationToken = default);
}