using MediatR;

namespace OMS.Application.Shared.Commands.Interfaces;

/// <summary>
/// Marker interface to represent a command
/// </summary>
public interface ICommand : IRequest
{
}

/// <summary>
/// Marker interface to represent a command
/// </summary>
/// <typeparam name="TResult">Simple value or locator (e.g true/false, an integer, a simple result) that is returned</typeparam>
public interface ICommand<out TResult> : IRequest<TResult>
{
}