using BankApp.Transactions.Core.Shared;

namespace BankApp.Transactions.Core;

public interface ITransactionsRepository
{
    Task AddTransactionAsync(Transaction transaction);
    Task<Transaction> GetTransactionById(Guid transactionId);
    Task<IReadOnlyList<Transaction>> GetTransactionsByRecipientId(UserId recipientId);
    Task<IReadOnlyList<Transaction>> GetTransactionsBySenderId(UserId senderId);
}