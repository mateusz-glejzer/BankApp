using BankApp.Identity.Infrastructure;

namespace BankApp.Identity.Api;

public class ModuleOptions
{
    public JwtOptions Jwt { get; set; }
}