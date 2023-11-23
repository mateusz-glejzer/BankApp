using System;

namespace BankApp.BankAccounts.Domain.Shared;

public record UserId(Guid Id)
{
    public static implicit operator UserId(Guid id) =>
        id.Equals(Guid.Empty) ? null : new UserId(id);
}