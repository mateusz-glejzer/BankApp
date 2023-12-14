using System;
using BankApp.Identity.Core.Models;

namespace BankApp.Identity.Core.Services;

public interface IJwtProvider
{
    AuthorizationDto Create(Guid userId, string role);
}