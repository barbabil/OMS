namespace OMS.Application.Shared.Queries.Interfaces;

public interface IQueryExecutor
{
    Task<TResult> Execute<TResult>(IQuery<TResult> query);
}