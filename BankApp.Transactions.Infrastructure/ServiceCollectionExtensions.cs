using BankApp.Transactions.Core.Commands.Dispatcher;
using BankApp.Transactions.Core.Events.Dispatcher;
using BankApp.Transactions.Core.Transactions;
using BankApp.Transactions.Infrastructure.Consumers;
using BankApp.Transactions.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.Transactions.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        
        var connectionString = configuration["ConnectionString"];
        services.AddDbContext<TransactionsDbContext>(optionsBuilder =>
            optionsBuilder.UseNpgsql(connectionString));
        services.AddScoped<ICommandDispatcher, CommandDispatcher>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ITransactionsRepository, TransactionsRepository>();
        services.AddHostedService<TransactionCreatedConsumer>();
        return services;
    }
}