using System;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Identity.Core.Identity.Models;
using BankApp.Identity.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Identity.Infrastructure;

public class SaltRepository : ISaltRepository
{
    private readonly IdentityDbContext _identityDbContext;

    public SaltRepository(IdentityDbContext identityDbContext)
    {
        _identityDbContext = identityDbContext;
    }

    public async Task<byte[]> GetSalt(Guid userId)
    {
        return (await _identityDbContext.Salts.SingleOrDefaultAsync(userSalt => userSalt.UserId == userId)).Salt;
    }

    public async Task SaveSalt(UserSalt salt)
    {
        await _identityDbContext.Salts.AddAsync(salt);
    }

    public async Task SaveChangesAsync()
    {
        await _identityDbContext.SaveChangesAsync();
    }
}