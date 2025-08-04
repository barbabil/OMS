using CSharpFunctionalExtensions;

namespace OMS.Domain.Menu;

public class Menu : Entity<short>
{
    private List<MenuItem> _menuItems = new();
    public IReadOnlyList<MenuItem> MenuItems => _menuItems;

    public Menu(List<MenuItem> menuItems)
    {
        _menuItems = menuItems;
    }

    protected Menu()
    {
        // Required by EF Core
    }

    public void AddMenuItem(MenuItem menuItem)
    {
    }

    public void RemoveMenuItem(MenuItem menuItem)
    {
    }

    public void EditMenuItem(MenuItem oldMenuItem,
                            MenuItem newMenuItem)
    {
    }
}