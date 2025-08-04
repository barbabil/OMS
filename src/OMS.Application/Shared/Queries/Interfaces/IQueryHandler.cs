using MediatR;

namespace OMS.Application.Shared.Queries.Interfaces;

public interface IQueryHandler<in TQuery, TResult> :
    IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
{
    /// <summary>
    /// Guard clause for preventing execution in case of an erroneous query
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    bool CanExecute(TQuery query);
}

public interface IQueryHandlerAsync<in TQuery, TResult> :
    IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
{
    /// <summary>
    /// Guard clause for preventing execution in case of an erroneous query
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    Task<bool> CanExecute(TQuery query);
}