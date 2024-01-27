using System.Collections.Generic;
using BankApp.BankAccounts.Core.Commands;
using BankApp.BankAccounts.Core.Commands.CommandHandlers;
using BankApp.BankAccounts.Core.Events.Dispatcher;
using BankApp.BankAccounts.Core.Events.EventHandlers;
using BankApp.BankAccounts.Core.Events.EventHandlers.Internal;
using BankApp.BankAccounts.Core.Events.IntegrationEvents.Internal;
using BankApp.BankAccounts.Core.Queries;
using BankApp.BankAccounts.Core.Queries.Dispatcher;
using BankApp.BankAccounts.Core.Queries.QueryHandlers;
using BankApp.BankAccounts.Domain.Accounts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.BankAccounts.Core.Extensions;

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