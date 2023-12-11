using BankApp.Shared.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Wallets.Infrastructure;

public class BankAccountDesignTimeContextFactory : BaseDesignTimeContextFactory<AccountsDbContext>
{
    protected override AccountsDbContext DbContextFactoryMethod(DbContextOptions<AccountsDbContext> options) =>
        new(options);
}