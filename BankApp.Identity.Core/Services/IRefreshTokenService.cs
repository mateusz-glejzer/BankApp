using BankApp.Identity.Core.Models;

namespace BankApp.Identity.Core.Services;

public interface IRefreshTokenService
{
    Task<string> CreateAsync(Guid userId);
    Task RevokeAsync(string refreshToken);
    Task<IdentityModel> UseAsync(string refreshToken);
}