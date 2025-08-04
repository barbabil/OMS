using CSharpFunctionalExtensions;

namespace OMS.Domain.Shared;

public sealed class LastName : ValueObject
{
    public static Result<LastName, Error> Instantiate(string lastName)
    {
        throw new NotImplementedException();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}
