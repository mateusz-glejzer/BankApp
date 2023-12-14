using BankApp.Identity.Core.Models;
using BankApp.Identity.Domain.User;

namespace BankApp.Identity.Core;

public interface IJwtProvider
{
    AuthorizationDto CreateToken(
        UserId userId,
        string role);
}