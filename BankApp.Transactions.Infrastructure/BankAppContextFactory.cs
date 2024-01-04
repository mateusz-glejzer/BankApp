using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BankApp.Transactions.Infrastructure;

public class BankAppContextFactory : IDesignTimeDbContextFactory<TransactionsDbContext>
{
    public TransactionsDbContext CreateDbContext(string[] args)
    {
        //TODO move connection string to config
        var optionsBuilder = new DbContextOptionsBuilder<TransactionsDbContext>();
        optionsBuilder.UseNpgsql(
            "Host=localhost; Database=bankApp-modular; Username=postgres;");

        return new TransactionsDbContext(optionsBuilder.Options);
    }
}