﻿using System.Threading;
using System.Threading.Tasks;

namespace BankApp.Transactions.Core.Queries.QueryHandlers;

public interface IQueryHandler<in TQuery> where TQuery :
    class, IQuery
{
    Task HandleAsync(TQuery query, CancellationToken cancellationToken = default);
}