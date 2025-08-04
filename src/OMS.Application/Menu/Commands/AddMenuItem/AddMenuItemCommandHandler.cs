using CSharpFunctionalExtensions;
using OMS.Application.Menu.Repositories.Interfaces;
using OMS.Application.Shared.Commands.Interfaces;
using OMS.Domain.Shared;

namespace OMS.Application.Menu.Commands.AddMenuItem;

public class AddMenuItemCommandHandler : ICommandHandler<AddMenuItemCommand, Result<int, Error>>
{
    private readonly IMenuItemsRepository _menuItemsRepository;

    public AddMenuItemCommandHandler(IMenuItemsRepository menuItemsRepository)
    {
        _menuItemsRepository = menuItemsRepository;
    }

    public async Task<Result<int, Error>> Handle(AddMenuItemCommand command,
                                           CancellationToken cancellationToken)
    {
        // Use case implementation of adding a menu item
        // repository calls

        return Random.Shared.Next();
    }
}