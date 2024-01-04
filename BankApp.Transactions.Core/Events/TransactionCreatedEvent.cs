using System;
using BankApp.Transactions.Core.Shared;
using BankApp.Transactions.Core.Transactions;

namespace BankApp.Transactions.Core.Events;

public record TransactionCreatedEvent(AccountId AccountId, Transaction Transaction) : IEvent;