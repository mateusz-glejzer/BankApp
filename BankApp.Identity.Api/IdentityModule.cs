using BankApp.Identity.Core.Extensions;
using BankApp.Identity.Infrastructure.Extensions;
using BankApp.Shared.Abstractions.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.Identity.Api;

public class IdentityModule : IModule
{
    public string Name => "IdentityModule";
    public string Path => "identity";

    public IReadOnlyList<EndpointInfo> GetEndpoints()
    {
        return new[]
        {
            new EndpointInfo("/login", HttpMethod.Get, () => "hello"),
            new EndpointInfo("/register", HttpMethod.Get, () => "hello"),
            new EndpointInfo("/refresh-token/use", HttpMethod.Get, () => "hello"),
        };
    }

    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddCore(configuration);
        services.AddInfrastructure(configuration);
    }
}