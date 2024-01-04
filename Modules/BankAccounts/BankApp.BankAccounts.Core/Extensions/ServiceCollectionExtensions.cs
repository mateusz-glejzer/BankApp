using System.Collections.Generic;
using BankApp.BankAccounts.Domain.Accounts;
using BankApp.Wallets.Core.Commands;
using BankApp.Wallets.Core.Commands.CommandHandlers;
using BankApp.Wallets.Core.Events.Dispatcher;
using BankApp.Wallets.Core.Events.EventHandlers;
using BankApp.Wallets.Core.Events.EventHandlers.Internal;
using BankApp.Wallets.Core.Events.IntegrationEvents.Internal;
using BankApp.Wallets.Core.Queries;
using BankApp.Wallets.Core.Queries.Dispatcher;
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
        services.AddScoped<ICommandHandler<CreateAccountCommand>, CreateAccountCommandHandler>();
        services.AddScoped<IQueryDispatcher, QueryDispatcher>();
        services.AddScoped<IQueryHandler<GetUserAccountsQuery, IReadOnlyList<Account>>, GetUserAccountsQueryHandler>();
        services.AddScoped<IEventHandler<TransactionCreatedIntegrationEvent>, TransactionCreatedIntegrationEventHandler>();
        services.AddSingleton<IEventDispatcher, EventDispatcher>();
        return services;
    }
}