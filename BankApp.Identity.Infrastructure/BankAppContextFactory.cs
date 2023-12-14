using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BankApp.Identity.Infrastructure;

public class UsersContextFactory : IDesignTimeDbContextFactory<UserDbContext>
{
    public UserDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<UserDbContext>();
        optionsBuilder.UseNpgsql(
            "Host=localhost; Database=bankApp-modular; Username=postgres; Password=matimati2137");

        return new UserDbContext(optionsBuilder.Options);
    }
}