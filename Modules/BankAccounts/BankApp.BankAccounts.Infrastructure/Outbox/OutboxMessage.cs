using System;

namespace BankApp.BankAccounts.Infrastructure.Outbox;

public class OutboxMessage
{
    public Guid MessageId { get; set; }
    public object Message { get; set; }
    public string SerializedMessage { get; set; }
    public string MessageType { get; set; }
    public DateTime SentAt { get; set; }

    public DateTime? ProcessedAt { get; set; }
}