using System.Threading.Tasks;

namespace BankApp.Wallets.Core;

public interface IMessageBroker
{
    Task PublishAsync<T>(T message) where T : class;
}