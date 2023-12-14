using System;

namespace BankApp.Identity.Core.Repositories;

public interface ISaltRepository
{
    byte[] GetSalt(Guid userId);
}