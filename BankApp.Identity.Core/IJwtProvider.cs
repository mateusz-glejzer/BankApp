using BankApp.Identity.Core.Models;

namespace BankApp.Identity.Core;

public interface IJwtProvider
{
    AuthorizationDto CreateToken(
        string userId,
        string role);
}