using System;
using System.Collections.Generic;
using System.Net.Http;
using BankApp.BankAccounts.Core.Commands;
using BankApp.BankAccounts.Core.Extensions;
using BankApp.BankAccounts.Core.Queries;
using BankApp.BankAccounts.Core.Queries.Dispatcher;
using BankApp.BankAccounts.Domain.Accounts;
using BankApp.BankAccounts.Infrastructure.Extensions;
using BankApp.Shared.Infrastructure.Configuration;
using BankApp.Shared.Infrastructure.Modules;
using Microsoft.AspNetCore.Mvc;
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

    public IReadOnlyList<EndpointInfo> GetEndpoints()
    {
        return new[]
        {
            new EndpointInfo("/userAccounts", HttpMethod.Get,
                async ([FromQuery] Guid userId, [FromServices] IQueryDispatcher queryDispatcher) =>
                await queryDispatcher.GetAsync<GetUserAccountsQuery, IReadOnlyList<Account>>(
                    new GetUserAccountsQuery(userId)), AuthorizationLevel.Client),
            new EndpointInfo("/account/create-transaction", HttpMethod.Post,
                async ([FromBody] CreateTransactionCommand request,
                    [FromServices] ICommandDispatcher commandDispatcher) =>
                {
                    await commandDispatcher.SendAsync(request);
                }, AuthorizationLevel.Client),
        };
    }
}