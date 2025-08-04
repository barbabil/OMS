using CSharpFunctionalExtensions;
using OMS.Application.Shared.Commands.Interfaces;
using OMS.Domain.Shared;

namespace OMS.Application.Menu.Commands.UpdateMenuItem;

public sealed record UpdateMenuItemCommand : ICommand<Result<bool, Error>>
{
    public UpdateMenuItemCommand(UpdateMenuItemRequest command)
    {
    }
}