using CSharpFunctionalExtensions;

namespace OMS.Domain.Shared;

public sealed class Vat : ValueObject
{
    public static Result<LastName, Error> Instantiate(string vat)
    {
        throw new NotImplementedException();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}