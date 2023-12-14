using System;
using BankApp.Identity.Domain.Shared;

namespace BankApp.Identity.Domain.User;

public class User : DomainEventsSource
{
    public UserId Id { get; private set; }
    public string Email { get; private set; }
    public string Role { get; private set; }
    public string Password { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public User(string email, string role, string password, UserId id = null, DateTime? createdAt = null)
    {
        Email = email;
        Role = role;
        Password = password;
        CreatedAt = createdAt ?? DateTime.UtcNow;
        Id = id ?? Guid.NewGuid();
    }
    
}