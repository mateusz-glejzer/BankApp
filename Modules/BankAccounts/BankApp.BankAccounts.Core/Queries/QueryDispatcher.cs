using System;
using System.Threading;
using System.Threading.Tasks;
using BankApp.Wallets.Core.Queries.QueryHandlers;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.Wallets.Core.Queries;

public class QueryDispatcher : IQueryDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public QueryDispatcher(IServiceProvider serviceProvider)
        => _serviceProvider = serviceProvider;


    public async Task<TResponse> GetAsync<TQuery, TResponse>(TQuery query, CancellationToken cancellationToken = default)
        where TQuery : class, IQuery
    {
        if (query is null)
        {
            return (TResponse)default;
        }

        using var scope = _serviceProvider.CreateScope();
        var handler = scope.ServiceProvider.GetRequiredService<IQueryHandler<TQuery, TResponse>>();
        return await handler.HandleAsync(query, cancellationToken);
    }
}