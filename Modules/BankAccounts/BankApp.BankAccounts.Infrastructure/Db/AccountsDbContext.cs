using BankApp.BankAccounts.Domain.Accounts;
using BankApp.Wallets.Infrastructure.Outbox;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Wallets.Infrastructure.Db;

public class AccountsDbContext : DbContext
{
    public AccountsDbContext(DbContextOptions<AccountsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<OutboxMessage> OutboxMessages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>()
            .HasKey(account => account.AccountId);
        modelBuilder.Entity<OutboxMessage>()
            .HasKey(message => message.MessageId);
    }
}