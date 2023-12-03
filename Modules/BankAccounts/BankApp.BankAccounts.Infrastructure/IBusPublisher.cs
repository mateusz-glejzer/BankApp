using System;
using System.Threading.Tasks;

namespace BankApp.Wallets.Infrastructure;

public interface IBusPublisher
{
    Task PublishAsync<T>(T message, Guid messageId) where T : class;
}