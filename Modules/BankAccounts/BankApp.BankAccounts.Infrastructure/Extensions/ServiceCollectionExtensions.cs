using BankApp.BankAccounts.Domain.Accounts.Repository;
using BankApp.Shared.Infrastructure;
using BankApp.Wallets.Core;
using BankApp.Wallets.Infrastructure.Outbox;
using BankApp.Wallets.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.Wallets.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // TODO add connection string for postgresql
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddDbContext<AccountsDbContext>(optionsBuilder =>
            optionsBuilder.UsePostgreSqlWithCustomMigrationTable<AccountsDbContext>(
                "Host=localhost; Database=bankApp-modular; Username=postgres; Password=matimati2137"));
        // services.AddHostedService<OutboxProcessor>();
        services.AddScoped<IMessageOutbox, MessageOutbox>();
        services.AddScoped<IMessageBroker, MessageBroker>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<OutboxRepository>();
        services.AddScoped<IBusPublisher, KafkaPublisher>();
        return services;
    }
}