using System.Threading;
using System.Threading.Tasks;
using BankApp.BankAccounts.Core.Commands;
using BankApp.BankAccounts.Core.Events.IntegrationEvents.External;
using BankApp.BankAccounts.Domain.Shared;
using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace BankApp.BankAccounts.Infrastructure.Consumers;

public class UserCreatedConsumer : BackgroundService
{
    private readonly IConsumer<Null, string> _consumer;
    private readonly ICommandDispatcher _commandDispatcher;

    public UserCreatedConsumer(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        var config = new ConsumerConfig() { BootstrapServers = "localhost:29092", GroupId = "bank_accounts" };
        _consumer = new ConsumerBuilder<Null, string>(config).Build();
        _consumer.Subscribe("user-created");
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var result = await Task.Run(() => _consumer.Consume(stoppingToken), stoppingToken);
            var message = result.Message;
            var userCreatedEvent = JsonConvert.DeserializeObject<UserCreatedEvent>(message.Value);
            await _commandDispatcher.SendAsync(new CreateAccountCommand(userCreatedEvent.UserId, Currency.PLN),
                stoppingToken);
        }

        _consumer.Close();
    }
}