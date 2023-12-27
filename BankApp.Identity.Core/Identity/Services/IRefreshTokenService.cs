using System;
using System.Threading.Tasks;
using BankApp.Identity.Core.Identity.Models;

namespace BankApp.Identity.Core.Identity.Services;

public interface IRefreshTokenService
{
    Task<string> CreateAsync(Guid userId);
    Task RevokeAsync(string refreshToken);
    Task<AuthorizationDto> UseAsync(string refreshToken);
}