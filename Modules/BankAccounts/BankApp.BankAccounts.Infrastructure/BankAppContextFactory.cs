using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BankApp.BankAccounts.Infrastructure;

public class BankAppContextFactory : IDesignTimeDbContextFactory<AccountsDbContext>
{
    public AccountsDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AccountsDbContext>();
        optionsBuilder.UseNpgsql(
            "Host=localhost; Database=bankApp-modular; Username=postgres; Password=matimati2137");

        return new AccountsDbContext(optionsBuilder.Options);
    }
}