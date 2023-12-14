using System;
using System.Linq;
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
}