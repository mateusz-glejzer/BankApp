using BankApp.Transactions.Core;
using BankApp.Transactions.Core.Shared;
using BankApp.Transactions.Core.Transactions;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Transactions.Infrastructure;

public class TransactionsDbContext : DbContext
{
    public TransactionsDbContext(DbContextOptions<TransactionsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaction>()
            .HasKey(transaction => transaction.TransactionId);
        modelBuilder.Entity<Transaction>().Property(transaction => transaction.TransactionId)
            .HasConversion(transactionId => transactionId.Id, id => new TransactionId(id));
        modelBuilder.Entity<Transaction>().Property(transaction => transaction.RecipientAccountId)
            .HasConversion(recipientAccountId => recipientAccountId.Id, id => new AccountId(id));
        modelBuilder.Entity<Transaction>().Property(transaction => transaction.SenderAccountId)
            .HasConversion(senderAccountId => senderAccountId.Id, id => new AccountId(id));
        modelBuilder.Entity<Transaction>().Property(transaction => transaction.Date)
            .HasConversion(a => a.Date, date => date);
    }
}