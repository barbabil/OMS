using CSharpFunctionalExtensions;
using OMS.Application.Menu.Repositories.Interfaces;
using OMS.Application.Shared.Commands.Interfaces;
using OMS.Domain.Shared;

namespace OMS.Application.Menu.Commands.UpdateMenuItem;

public class UpdateMenuItemHandler : ICommandHandler<UpdateMenuItemCommand, Result<bool, Error>>
{
    private readonly IMenuItemsRepository _menuItemsRepository;

    public UpdateMenuItemHandler(IMenuItemsRepository menuItemsRepository)
    {
        _menuItemsRepository = menuItemsRepository;
    }

    public async Task<Result<bool, Error>> Handle(UpdateMenuItemCommand command,
                                            CancellationToken cancellationToken)
    {
        // Use case implementation of editing a menu item
        // repository calls

        return true;
    }
}