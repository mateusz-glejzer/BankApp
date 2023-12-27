﻿using System;
using System.Threading.Tasks;

namespace BankApp.BankAccounts.Infrastructure;

public interface IPublisher
{
    Task PublishAsync<T>(string topic, T message, Guid messageId) where T : class;
}