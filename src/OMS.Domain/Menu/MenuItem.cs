using Ardalis.GuardClauses;
using CSharpFunctionalExtensions;
using OMS.Domain.Shared;

namespace OMS.Domain.Menu;

public class MenuItem : Entity<int>
{
    private MenuItem(string name,
                    string description,
                    decimal price,
                    bool isAvailable)
    {
        Name = name;
        Description = description;
        Price = price;
        IsAvailable = isAvailable;
    }

    public string Description { get; private set; }
    public bool IsAvailable { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }

    public static Result<MenuItem, Error> Instantiate(string name,
                                                      string description,
                                                      decimal price,
                                                      bool isAvailable)
    {
        // name cannot be null
        Guard.Against.Null(name, nameof(name));
        // description cannot be null
        Guard.Against.Null(description, nameof(description));
        // price must be greater than zero and cannot be negative
        Guard.Against.NegativeOrZero(price, nameof(price));

        return new MenuItem(name, description, price, isAvailable);
    }

    public void UpdateAvailability(bool isAvailable)
    {
    }

    public void UpdatePrice(decimal newPrice)
    {
    }
}