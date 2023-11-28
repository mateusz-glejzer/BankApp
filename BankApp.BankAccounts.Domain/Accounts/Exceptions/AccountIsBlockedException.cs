namespace BankApp.BankAccounts.Domain.Accounts.Exceptions;

public class AccountIsBlockedException : DomainException
{
    public AccountIsBlockedException() : base("Account is blocked, cannot perform this operation",
        ExceptionCategory.ValidationError)
    {
    }
}