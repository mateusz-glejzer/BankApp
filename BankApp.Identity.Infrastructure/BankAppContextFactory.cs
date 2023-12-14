using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BankApp.Identity.Infrastructure;

public class UsersContextFactory : IDesignTimeDbContextFactory<IdentityDbContext>
{
    public IdentityDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<IdentityDbContext>();
        optionsBuilder.UseNpgsql(
            "Host=localhost; Database=bankApp-modular; Username=postgres; Password=matimati2137");

        return new IdentityDbContext(optionsBuilder.Options);
    }
}