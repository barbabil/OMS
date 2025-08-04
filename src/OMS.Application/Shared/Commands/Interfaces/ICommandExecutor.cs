namespace OMS.Application.Shared.Commands.Interfaces;

public interface ICommandExecutor
{
    Task Execute(ICommand command);

    Task<TResult> Execute<TResult>(ICommand<TResult> command);
}