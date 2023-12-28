using System;
using BankApp.BankAccounts.Domain.Shared;

namespace BankApp.Wallets.Core.Events.IntegrationEvents.External;

public class UserCreatedEvent : IEvent
{
    public UserId UserId { get; set; }
}