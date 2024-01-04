using BankApp.Identity.Infrastructure;
using BankApp.Identity.Infrastructure.Jwt;
using BankApp.Shared.Infrastructure;

namespace BankApp.Identity.Api;

public class ModuleOptions
{
    public JwtOptions Jwt { get; set; }
}