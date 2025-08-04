using CSharpFunctionalExtensions;
using OMS.Application.Shared.Commands.Interfaces;
using OMS.Domain.Shared;

namespace OMS.Application.Menu.Commands.AddMenuItem;

public sealed record AddMenuItemCommand : ICommand<Result<int, Error>>
{
    public AddMenuItemCommand(AddMenuItemRequest request)
    {
    }
}