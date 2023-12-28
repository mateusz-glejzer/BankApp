using System;
using BankApp.Identity.Domain.Shared;
using BankApp.Identity.Domain.Shared.Events;

namespace BankApp.Identity.Domain.User;

public class User : DomainEventsSource
{
    public UserId Id { get; private set; }
    public string Email { get; private set; }
    public Roles Role { get; private set; }
    public string Password { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public User(string email, Roles role, string password)
    {
        Email = email;
        Role = role;
        Password = password;
        CreatedAt = DateTime.UtcNow;
        Id = new UserId(Guid.NewGuid());
        _domainEvents.Enqueue(new UserCreatedEvent
        {
            UserId = Id,
        });
    }
}