using CSharpFunctionalExtensions;
using OMS.Application.Shared.Queries.Interfaces;

namespace OMS.Application.Menu.Queries.GetMenuItems;

public record ViewMenuItemsReponse : IQueryResponse
{
    public Object Result { get; private set; }

    public ViewMenuItemsReponse(object input)
    {
        this.Result = input;
    }
}