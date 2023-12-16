using System;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Identity.Core.Models;
using BankApp.Identity.Core.Repositories;

namespace BankApp.Identity.Infrastructure;

public class SaltRepository : ISaltRepository
{
    private readonly IdentityDbContext _identityDbContext;

    public SaltRepository(IdentityDbContext identityDbContext)
    {
        _identityDbContext = identityDbContext;
    }

    public byte[] GetSalt(Guid userId)
    {
        return _identityDbContext.Salts.Single(userSalt => userSalt.UserId == userId).Salt;
    }

    public async Task SaveSalt(UserSalt salt)
    {
        await _identityDbContext.Salts.AddAsync(salt);
    }
}