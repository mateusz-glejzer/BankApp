using BankApp.BankAccounts.Domain.Accounts.Repository;
using BankApp.BankAccounts.Infrastructure.Consumers;
using BankApp.BankAccounts.Infrastructure.MessageProducers;
using BankApp.BankAccounts.Infrastructure.Outbox;
using BankApp.BankAccounts.Infrastructure.Repositories;
using BankApp.Wallets.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace BankApp.BankAccounts.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["ConnectionString"];
        services.AddDbContext<AccountsDbContext>(optionsBuilder =>
            optionsBuilder.UseNpgsql(
                connectionString));
        services.AddScoped<IMessageOutbox, MessageOutbox>();
        services.AddScoped<IMessageBroker, MessageBroker>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IOutboxRepository, OutboxRepository>();
        services.AddSingleton<IPublisher, KafkaPublisher>();
        services.AddQuartz();
        services.AddQuartzHostedService(options => { options.WaitForJobsToComplete = true; });
        services.ConfigureOptions<OutboxProcessorScheduledJobOptions>();
        services.AddHostedService<UserCreatedConsumer>();
        return services;
    }
}