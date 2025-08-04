using CSharpFunctionalExtensions;
using OMS.Application.Menu.Repositories.Interfaces;
using OMS.Application.Shared.Commands.Interfaces;
using OMS.Domain.Shared;

namespace OMS.Application.Menu.Commands.RemoveMenuItem;

public class RemoveMenuItemCommandHandler : ICommandHandler<RemoveMenuItemCommand, Result<bool, Error>>
{
    private readonly IMenuItemsRepository _menuItemsRepository;

    public RemoveMenuItemCommandHandler(IMenuItemsRepository menuItemsRepository)
    {
        _menuItemsRepository = menuItemsRepository;
    }

    public async Task<Result<bool, Error>> Handle(RemoveMenuItemCommand request,
                                            CancellationToken cancellationToken)
    {
        // Use case implementation of removing a menu item
        // repository calls

        return true;
    }
}