using BankApp.BankAccounts.Domain.Accounts.Repository;
using BankApp.BankAccounts.Infrastructure.Outbox;
using BankApp.BankAccounts.Infrastructure.Repositories;
using BankApp.Wallets.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.BankAccounts.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // TODO add connection string for postgresql
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddDbContext<AccountsDbContext>(optionsBuilder =>
            optionsBuilder.UseNpgsql(
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