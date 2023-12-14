using System.Linq;
using System.Threading.Tasks;
using BankApp.Identity.Core.Repositories;
using BankApp.Identity.Domain.User;

namespace BankApp.Identity.Infrastructure;

public class UserRepository : IUserRepository
{
    private readonly IdentityDbContext _dbContext;

    public UserRepository(IdentityDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> GetAsync(string email)
    {
        return _dbContext.Users.Single(user => user.Email == email);
    }

    public async Task AddAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
    }
}