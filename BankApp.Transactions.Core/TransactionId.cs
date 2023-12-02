﻿namespace BankApp.Transactions.Core;

public record TransactionId(Guid Id)
{
    public static implicit operator TransactionId(Guid id) =>
        id.Equals(Guid.Empty) ? null : new TransactionId(id);
}