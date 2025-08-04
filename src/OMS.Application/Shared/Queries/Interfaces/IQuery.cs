using MediatR;

namespace OMS.Application.Shared.Queries.Interfaces;

/// <summary>
/// Marker interface to represent a query
/// </summary>
/// <typeparam name="TResult">Object that is returned</typeparam>
public interface IQuery<out TResult> : IRequest<TResult>
{
}