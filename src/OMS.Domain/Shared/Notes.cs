using CSharpFunctionalExtensions;

namespace OMS.Domain.Shared;

public sealed class Notes : ValueObject
{
    public static Result<Notes, Error> Instantiate(string? notes)
    {
        throw new NotImplementedException();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}