using System.Threading.Tasks;
using BankApp.Identity.Core.Repositories;
using BankApp.Identity.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Identity.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IdentityDbContext _dbContext;

    public UserRepository(IdentityDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> GetAsync(string email)
    {
        return await _dbContext.Users.SingleOrDefaultAsync(user => user.Email == email);
    }

    public async Task AddAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}