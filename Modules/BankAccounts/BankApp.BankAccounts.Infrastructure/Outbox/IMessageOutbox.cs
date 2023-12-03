using System;
using System.Threading.Tasks;

namespace BankApp.Wallets.Infrastructure.Outbox;

public interface IMessageOutbox
{
    Task SendAsync<T>(T message, Guid messageId) where T : class;
}