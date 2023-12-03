using BankApp.BankAccounts.Domain.Accounts.Repository;
using BankApp.Wallets.Infrastructure.Outbox;
using BankApp.Wallets.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.Wallets.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // TODO add connection string for postgresql
        services.AddDbContext<AccountsDbContext>();
        services.AddHostedService<OutboxProcessor>();
        services.AddScoped<IMessageOutbox, MessageOutbox>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        return services;
    }
}