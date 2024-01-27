using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BankApp.Shared.Infrastructure.Configuration;
using BankApp.Shared.Infrastructure.Modules;
using BankApp.Transactions.Core;
using BankApp.Transactions.Core.Queries;
using BankApp.Transactions.Core.Queries.Dispatcher;
using BankApp.Transactions.Core.Shared;
using BankApp.Transactions.Core.Transactions;
using BankApp.Transactions.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.Transactions.Api;

public class TransactionsModule : IModule
{
    public string Name => "Transactions";
    public string Path => "transactions-module";

    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddCore(configuration);
        services.AddInfrastructure(configuration);
    }


    public IReadOnlyList<EndpointInfo> GetEndpoints()
    {
        return new[]
        {
            new EndpointInfo("/account-transactions", HttpMethod.Get,
                new Func<Guid, int, int, IQueryDispatcher, Task<IReadOnlyList<Transaction>>>(async (
                        [FromQuery] Guid AccountId, [FromQuery] int Page, [FromQuery] int ItemsPerPage,
                        [FromServices] IQueryDispatcher queryDispatcher) =>
                    await queryDispatcher.GetAsync(new GetTransactionsQuery(new AccountId(AccountId), Page,
                        ItemsPerPage))),
                AuthorizationLevel.Client),
        };
    }
}