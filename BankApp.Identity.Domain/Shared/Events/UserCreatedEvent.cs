using System;
using BankApp.Identity.Domain.User;

namespace BankApp.Identity.Domain.Shared.Events;

public class UserCreatedEvent : IDomainEvent
{
    public UserId UserId { get; set; }
}