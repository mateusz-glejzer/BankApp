using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BankApp.BankAccounts.Infrastructure;

public class BankAppContextFactory : IDesignTimeDbContextFactory<AccountsDbContext>
{
    public AccountsDbContext CreateDbContext(string[] args)
    {
        //TODO move connection string to config
        var optionsBuilder = new DbContextOptionsBuilder<AccountsDbContext>();
        optionsBuilder.UseNpgsql(
            "Host=localhost; Database=bankApp-modular; Username=postgres;");

        return new AccountsDbContext(optionsBuilder.Options);
    }
}