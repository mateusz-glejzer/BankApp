using System;
using System.Threading;
using System.Threading.Tasks;
using BankApp.Transactions.Core.Queries.QueryHandlers;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.Transactions.Core.Queries.Dispatcher;

public class QueryDispatcher : IQueryDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public QueryDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<TResult> GetAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default)
    {
        using var scope = _serviceProvider.CreateScope();
        var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
        var handler = scope.ServiceProvider.GetRequiredService(handlerType);
        var method = handlerType.GetMethod(nameof(IQueryHandler<IQuery<TResult>, TResult>.HandleAsync));

        return await (Task<TResult>)method.Invoke(handler, new object[] { query, cancellationToken });
    }
}