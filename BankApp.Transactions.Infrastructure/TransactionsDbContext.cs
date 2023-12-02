using BankApp.Transactions.Core;
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
    }
}