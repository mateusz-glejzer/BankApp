using System.Collections.Generic;
using System.Net.Http;
using BankApp.Shared.Abstractions.Modules;
using BankApp.Wallets.Core.Extensions;
using BankApp.Wallets.Infrastructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.BankAccounts.Api;

public class BankAccountsModule : IModule
{
    public string Name => "BankAccounts";
    public string Path => "bank-accounts-module";

    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddCore(configuration);
        services.AddInfrastructure(configuration);
    }


    public void Use(IApplicationBuilder app)
    {
        throw new System.NotImplementedException();
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