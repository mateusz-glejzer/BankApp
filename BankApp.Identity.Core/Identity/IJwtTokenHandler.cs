using BankApp.Identity.Core.Identity.Models;
using BankApp.Identity.Domain.User;

namespace BankApp.Identity.Core.Identity;

public interface IJwtTokenHandler
{
    AuthorizationDto CreateToken(
        UserId userId,
        Roles role);
}