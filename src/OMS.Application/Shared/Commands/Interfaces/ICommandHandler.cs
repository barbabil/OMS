using MediatR;

namespace OMS.Application.Shared.Commands.Interfaces;

/// <summary>
/// Marker interface to represent a handler of commands
/// </summary>
/// <typeparam name="TCommand">Command object that will be handled</typeparam>
public interface ICommandHandler<in TCommand> :
    IRequestHandler<TCommand> where TCommand : ICommand
{
}

/// <summary>
/// Marker interface to represent a handler of commands
/// </summary>
/// <typeparam name="TCommand">Command object that will be handled</typeparam>
/// <typeparam name="TResult">Simple value or locator (e.g true/false, an integer, a simple result) that is returned</typeparam>
public interface ICommandHandler<in TCommand, TResult> :
    IRequestHandler<TCommand, TResult> where TCommand : ICommand<TResult>
{
}