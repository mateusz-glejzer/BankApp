using System;

namespace BankApp.BankAccounts.Domain.Accounts;

public record AccountId(Guid Id)
{
    public static implicit operator AccountId(Guid id) =>
        id.Equals(Guid.Empty) ? null : new AccountId(id);
}