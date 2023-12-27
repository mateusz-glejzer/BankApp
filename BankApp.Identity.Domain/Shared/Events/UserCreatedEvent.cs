using System;
using BankApp.Identity.Domain.User;

namespace BankApp.Identity.Domain.Shared.Events;

public class UserCreatedEvent : IDomainEvent
{
    public Guid EventId { get; set; }
    public UserId UserId { get; set; }
    public DateTime DateTime { get; set; }
}