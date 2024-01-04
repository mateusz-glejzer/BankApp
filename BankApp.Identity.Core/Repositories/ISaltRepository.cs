using System;
using System.Threading.Tasks;
using BankApp.Identity.Core.Identity.Models;

namespace BankApp.Identity.Core.Repositories;

public interface ISaltRepository
{
    Task<byte[]> GetSalt(Guid userId);
    Task AddSaltAsync(UserSalt salt);
    Task SaveChangesAsync();
}