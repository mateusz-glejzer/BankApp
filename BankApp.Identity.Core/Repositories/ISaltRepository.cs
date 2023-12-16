using System;
using System.Threading.Tasks;
using BankApp.Identity.Core.Models;

namespace BankApp.Identity.Core.Repositories;

public interface ISaltRepository
{
    byte[] GetSalt(Guid userId);
    Task SaveSalt(UserSalt salt);
}