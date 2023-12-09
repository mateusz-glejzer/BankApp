using BankApp.Shared.Abstractions.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.Identity.Api;

public class IdentityModule : IModule
{
    public string Name => "IdentityModule";
    public string Path => "identity";
    public IReadOnlyList<EndpointInfo> GetEndpoints()
    {
        throw new NotImplementedException();
    }

    public void Use(IApplicationBuilder app)
    {
        throw new NotImplementedException();
    }

    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        throw new NotImplementedException();
    }
}