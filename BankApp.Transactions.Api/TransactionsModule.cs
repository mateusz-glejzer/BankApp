using BankApp.Shared.Abstractions.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.Transactions.Api;

public class TransactionsModule : IModule
{
    public string Name => "Transactions";
    public string Path => "transactions-module";

    public void Register(IServiceCollection services, IConfiguration configuration)
    {
    }

    public void Use(IApplicationBuilder app)
    {
    }

    public IReadOnlyList<EndpointInfo> GetEndpoints()
    {
        return new[]
        {
            new EndpointInfo("", HttpMethod.Get, () => ""),
            new EndpointInfo("", HttpMethod.Post, (HttpContext context) => { }),
        };
    }
}