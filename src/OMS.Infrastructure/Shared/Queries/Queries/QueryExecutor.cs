using MediatR;
using OMS.Application.Shared.Queries.Interfaces;

namespace OMS.Infrastructure.Shared.Queries.Queries;

public class QueryExecutor : IQueryExecutor
{
    private IMediator _mediator;

    public QueryExecutor(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<TResult> Execute<TResult>(IQuery<TResult> query)
    {
        return await _mediator.Send(query);
    }
}