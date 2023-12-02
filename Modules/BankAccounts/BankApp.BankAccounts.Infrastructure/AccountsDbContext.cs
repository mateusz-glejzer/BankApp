using BankApp.BankAccounts.Domain.Accounts;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Wallets.Infrastructure;

public class AccountsDbContext : DbContext
{
    public AccountsDbContext(DbContextOptions<AccountsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Account> Accounts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>()
            .HasKey(account => account.AccountId);
    }
}