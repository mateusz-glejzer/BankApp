using System.Collections.Generic;
using BankApp.Transactions.Core.Commands.Dispatcher;
using BankApp.Transactions.Core.Events;
using BankApp.Transactions.Core.Events.Dispatcher;
using BankApp.Transactions.Core.Events.EventHandlers;
using BankApp.Transactions.Core.Queries;
using BankApp.Transactions.Core.Queries.Dispatcher;
using BankApp.Transactions.Core.Queries.QueryHandlers;
using BankApp.Transactions.Core.Transactions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.Transactions.Core;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<ICommandDispatcher, CommandDispatcher>();
        services.AddSingleton<IEventDispatcher, EventDispatcher>();
        services.AddScoped<IEventHandler<TransactionCreatedEvent>, TransactionCreatedEventHandler>();
        services.AddSingleton<IQueryDispatcher, QueryDispatcher>();
        services.AddScoped<IQueryHandler<GetTransactionsQuery, IReadOnlyList<Transaction>>, GetTransactionsQueryHandler>();
        return services;
    }
}