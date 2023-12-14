using System;

namespace BankApp.Identity.Domain.User;

public record UserId(Guid Id)
{
    public static implicit operator UserId(Guid id) =>
        id.Equals(Guid.Empty) ? null : new UserId(id);
}