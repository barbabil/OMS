using System.Text;
using FluentValidation;
using MediatR;
using OMS.Application.Shared.Exceptions;

namespace OMS.Application.Shared.Validations;

public class CommandValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public CommandValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var errors = (await Task.WhenAll(_validators.Select(v => v.ValidateAsync(request)))).
                                Where(result => result != null).
                                SelectMany(result => result.Errors).
                                Where(error => error != null).
                                ToList();

        if (errors.Any())
        {
            var errorBuilder = new StringBuilder();

            foreach (var error in errors)
            {
                errorBuilder.Append(error.ErrorMessage + Environment.NewLine);
            }

            //remove the annoying "Environment.NewLine" characters from the end of the stringified error
            var errorStringified = errorBuilder.ToString();
            errorStringified = errorStringified.Substring(0, errorStringified.Length - Environment.NewLine.Length);

            throw new OMSApplicationException(errorStringified);
        }

        return await next();
    }
}