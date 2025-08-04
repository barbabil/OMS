using OMS.Domain.Menu;

namespace OMS.Application.Menu.Repositories.Interfaces;

/// <summary>
///
/// </summary>
public interface IMenuItemsRepository
{
    ///Includes method signatures for managing the repository (data access) of menu items

    MenuItem GetMenuItem(int menuItemId);

    IReadOnlyList<MenuItem> GetMenuItems();
}