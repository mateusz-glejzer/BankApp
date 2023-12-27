using BankApp.BankAccounts.Domain.Accounts;
using BankApp.BankAccounts.Domain.Shared;
using BankApp.BankAccounts.Infrastructure.Outbox;
using Microsoft.EntityFrameworkCore;

namespace BankApp.BankAccounts.Infrastructure;

public class AccountsDbContext : DbContext
{
    public AccountsDbContext(DbContextOptions<AccountsDbContext> options)
        : base(options)
    {
    }

    public AccountsDbContext() : base()
    {
    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<OutboxMessage> OutboxMessages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("bankAccounts");
        modelBuilder.Entity<Account>()
            .HasKey(account => account.AccountId);
        modelBuilder.Entity<Account>().Property(account => account.AccountId)
            .HasConversion(accountId => accountId.Id, id => new AccountId(id));
        modelBuilder.Entity<Account>().Property(account => account.UserId)
            .HasConversion(userId => userId.Id, id => new UserId(id));
        
        modelBuilder.Entity<OutboxMessage>()
            .HasKey(message => message.MessageId);
        modelBuilder.Entity<OutboxMessage>().Ignore(account => account.Message);
    }
}