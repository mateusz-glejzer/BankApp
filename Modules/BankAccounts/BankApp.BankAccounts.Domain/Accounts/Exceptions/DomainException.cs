using System;

namespace BankApp.BankAccounts.Domain.Accounts.Exceptions;

public class DomainException : Exception
{
    public ExceptionCategory ExceptionCategory { get; }

    public DomainException(string message, ExceptionCategory exceptionCategory) : base(message)
    {
        ExceptionCategory = exceptionCategory;
    }
}

public enum ExceptionCategory
{
    ValidationError,
    NotFound,
    AlreadyExists,
    ConcurrencyError,
    TechnicalError
}