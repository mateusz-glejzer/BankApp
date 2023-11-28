using System.Collections.Generic;
using System.Linq;

namespace BankApp.BankAccounts.Domain.Shared.Events;

public abstract class DomainEventsSource
{
    protected Queue<IDomainEvent> _domainEvents = new();

    public IReadOnlyCollection<IDomainEvent> DomainEvents
    {
        get
        {
            var result = _domainEvents.ToList();
            _domainEvents.Clear();
            return result;
        }
    }
}