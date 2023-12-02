using BankApp.Transactions.Core;
using BankApp.Transactions.Core.Exceptions;
using BankApp.Transactions.Core.Shared;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Transactions.Infrastructure;

public class TransactionRepository : ITransactionsRepository
{
    private readonly TransactionsDbContext _dbContext;

    public TransactionRepository(TransactionsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddTransactionAsync(Transaction transaction)
    {
        await _dbContext.AddAsync(transaction);
    }

    public async Task<Transaction> GetTransactionById(Guid transactionId)
    {
        var transaction = await _dbContext.Transactions.FindAsync(transactionId);
        if (transaction is null)
        {
            throw new TransactionDoesNotExistsException(transactionId);
        }

        return transaction;
    }

    public async Task<IReadOnlyList<Transaction>> GetTransactionsByRecipientId(UserId recipientId)
    {
        return await _dbContext.Transactions.Where(transaction => transaction.Recipient.Id == recipientId)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Transaction>> GetTransactionsBySenderId(UserId senderId)
    {
        return await _dbContext.Transactions.Where(transaction => transaction.Sender.Id == senderId)
            .ToListAsync();
    }
}