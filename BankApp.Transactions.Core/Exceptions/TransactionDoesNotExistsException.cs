using System;

namespace BankApp.Transactions.Core.Exceptions;

public class TransactionDoesNotExistsException : Exception
{
    public TransactionDoesNotExistsException(Guid transactionId)
        : base($"Transaction with id: {transactionId} doesn't exists")
    {
    }
}