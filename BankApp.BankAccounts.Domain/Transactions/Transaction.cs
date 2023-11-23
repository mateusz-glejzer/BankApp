namespace BankApp.Transactions.Domain;

public class Transaction
{
    public Transaction(Guid recipientId, Guid senderId, double amount, Currency currency)
    {
        AccountId = new Guid();
        _recipientId = recipientId;
    }

    public Guid AccountId { get; init; }
    public   { get; init; }
}