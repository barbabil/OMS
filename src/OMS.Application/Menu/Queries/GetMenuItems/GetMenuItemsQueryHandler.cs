using OMS.Application.Menu.Repositories.Interfaces;
using OMS.Application.Shared.Queries.Interfaces;
using OMS.Domain.Menu;

namespace OMS.Application.Menu.Queries.GetMenuItems;

public class GetMenuItemsQueryHandler : IQueryHandler<GetMenuItemsQuery, ViewMenuItemsReponse>
{
    private readonly IMenuItemsRepository _menuItemsRepository;

    public GetMenuItemsQueryHandler(IMenuItemsRepository menuItemsRepository)
    {
        _menuItemsRepository = menuItemsRepository;
    }

    public bool CanExecute(GetMenuItemsQuery query)
    {
        return true;
    }

    public async Task<ViewMenuItemsReponse> Handle(GetMenuItemsQuery query,
                                                  CancellationToken cancellationToken)
    {
        if (!CanExecute(query))
            return new ViewMenuItemsReponse(new List<MenuItem>());

        // Use case implementation of fetching one or more menu items
        // repository calls

        return new ViewMenuItemsReponse(new List<MenuItem>()
        {
            MenuItem.Instantiate("Greek salad", "Greek salad description", 8.5m, true).Value
        });
    }
}