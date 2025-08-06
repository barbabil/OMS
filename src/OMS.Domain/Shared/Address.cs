using CSharpFunctionalExtensions;

namespace OMS.Domain.Shared;

public sealed class Address : ValueObject
{
    public static Result<Address, Error> Instantiate(string address,
                                                      string number,
                                                      string city,
                                                      string region,
                                                      string postalCode)
    {
        throw new NotImplementedException();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}