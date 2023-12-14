using System.Collections.Generic;
using System.Linq;
using BankApp.Identity.Domain.Shared.Events;

namespace BankApp.Identity.Domain.Shared;

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