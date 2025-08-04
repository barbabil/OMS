using OMS.Application.Shared.Queries.Interfaces;

namespace OMS.Application.Menu.Queries.GetMenuItems;

public record GetMenuItemsQuery : IQuery<ViewMenuItemsReponse>
{
    public GetMenuItemsQuery(GetMenuItemsRequest request)
    {
    }
}