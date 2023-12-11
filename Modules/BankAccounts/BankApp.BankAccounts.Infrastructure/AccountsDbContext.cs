using BankApp.BankAccounts.Domain.Accounts;
using BankApp.Wallets.Infrastructure.Outbox;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Wallets.Infrastructure;

public class AccountsDbContext : DbContext
{
    public AccountsDbContext(DbContextOptions<AccountsDbContext> options)
        : base(options)
    {
    }

    public AccountsDbContext()
    {
    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<OutboxMessage> OutboxMessages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("bankAccounts");
        modelBuilder.Entity<Account>()
            .HasKey(account => account.AccountId);
        modelBuilder.Entity<OutboxMessage>()
            .HasKey(message => message.MessageId);
    }
}