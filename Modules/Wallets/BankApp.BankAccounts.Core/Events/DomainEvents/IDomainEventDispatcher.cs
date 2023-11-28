using System.Threading;
using System.Threading.Tasks;
using BankApp.BankAccounts.Domain.Shared.Events;

namespace BankApp.Wallets.Core.Events.DomainEvents;

public interface IDomainEventDispatcher
{
    Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
        where TEvent : class, IDomainEvent;
}