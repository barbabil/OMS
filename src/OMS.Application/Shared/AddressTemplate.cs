using DomainAddress = OMS.Domain.Shared.Address;

namespace OMS.Application.Shared;

public record AddressTemplate
{
    public string Address { get; private set; } = string.Empty;
    public string City { get; private set; } = string.Empty;

    public string Number { get; private set; } = string.Empty;

    public string Region { get; private set; } = string.Empty;

    public string PostalCode { get; private set; } = string.Empty;

    public DomainAddress ToDomain()
    {
        return DomainAddress.Instantiate(Address, Number, City, Region, PostalCode).Value;
    }
}