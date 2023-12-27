using System;
using System.Threading.Tasks;

namespace BankApp.Identity.Infrastructure;

public interface IBusPublisher
{
    Task PublishAsync<T>(string topic, T message, Guid messageId) where T : class;
}