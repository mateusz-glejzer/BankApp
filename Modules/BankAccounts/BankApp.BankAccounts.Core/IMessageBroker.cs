using System.Threading.Tasks;

namespace BankApp.Wallets.Core;

public interface IMessageBroker
{
    Task PublishAsync<T>(T message, string messageId = null) where T : class;
}