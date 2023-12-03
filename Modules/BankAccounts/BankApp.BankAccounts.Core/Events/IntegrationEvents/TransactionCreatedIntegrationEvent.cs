﻿using BankApp.BankAccounts.Domain.Accounts;
using BankApp.BankAccounts.Domain.Transactions;

namespace BankApp.Wallets.Core.Events.IntegrationEvents;

public record TransactionCreatedIntegrationEvent(AccountId AccountId, Transaction Transaction) : IEvent;