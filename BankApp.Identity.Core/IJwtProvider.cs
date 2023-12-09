using BankApp.Identity.Core.Models;

namespace BankApp.Identity.Core;

public interface IJwtProvider
{
    IdentityModel CreateToken(
        string userId,
        string role);
}