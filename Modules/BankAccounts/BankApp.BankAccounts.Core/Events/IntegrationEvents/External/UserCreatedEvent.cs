using System;
using BankApp.BankAccounts.Domain.Shared;

namespace BankApp.Wallets.Core.Events.IntegrationEvents.External;

public class UserCreatedEvent : IEvent
{
    public Guid EventId { get; set; }
    public UserId UserId { get; set; }
    public DateTime DateTime { get; set; }
}