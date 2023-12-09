using System.Collections.Generic;
using BankApp.BankAccounts.Domain.Accounts;
using BankApp.Wallets.Core.Commands;
using BankApp.Wallets.Core.Commands.CommandHandlers;
using BankApp.Wallets.Core.Queries;
using BankApp.Wallets.Core.Queries.QueryHandlers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.Wallets.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<ICommandDispatcher, CommandDispatcher>();
        services.AddScoped<ICommandHandler<CreateTransactionCommand>, CreateTransactionCommandHandler>();
        services.AddScoped<IQueryHandler<GetUserAccountsQuery, IReadOnlyList<Account>>, GetUserAccountsQueryHandler>();
        return services;
    }
}