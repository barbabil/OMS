using CSharpFunctionalExtensions;
using OMS.Application.Shared.Commands.Interfaces;
using OMS.Domain.Shared;

namespace OMS.Application.Menu.Commands.RemoveMenuItem;

public sealed record RemoveMenuItemCommand : ICommand<Result<bool, Error>>
{
    public RemoveMenuItemCommand(int id)
    {
    }
}