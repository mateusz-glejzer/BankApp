namespace BankApp.BankAccounts.Domain.Accounts.Exceptions;

public class TransactionAmountIsNotPositiveNumberException : DomainException
{
    public TransactionAmountIsNotPositiveNumberException() : base(
        "Transaction amount should be a positive number.", ExceptionCategory.ValidationError)
    {
    }
}