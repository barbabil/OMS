using OMS.Application.Menu.Repositories.Interfaces;
using OMS.Domain.Menu;

namespace OMS.Persistence.Menu;

public class MenuItemsRepository : IMenuItemsRepository
{
    public MenuItem GetMenuItem(int menuItemId)
    {
        return MenuItem.Instantiate("Greek salad", "Greek salad description", 8.5m, true).Value;
    }

    public IReadOnlyList<MenuItem> GetMenuItems()
    {
        return new List<MenuItem>
                {
                    MenuItem.Instantiate("Greek salad", "Greek salad description", 8.5m, true).Value,
                    MenuItem.Instantiate("Wine", "White glass of wine", 5m, true).Value
                };
    }
}