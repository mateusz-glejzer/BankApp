using System.Collections.Generic;
using System.Net.Http;
using BankApp.Shared.Infrastructure.Configuration;
using BankApp.Shared.Infrastructure.Modules;
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


    public IReadOnlyList<EndpointInfo> GetEndpoints()
    {
        return new[]
        {
            new EndpointInfo("", HttpMethod.Get, () => "", AuthorizationLevel.Client),
            new EndpointInfo("", HttpMethod.Post, (HttpContext context) => { }, AuthorizationLevel.Client),
        };
    }
}