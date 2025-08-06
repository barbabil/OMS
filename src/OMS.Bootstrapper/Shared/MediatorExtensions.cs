using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using OMS.Application.Orders.Commands.PlaceOrder;
using OMS.Application.Shared.Commands.Interfaces;
using OMS.Application.Shared.Queries.Interfaces;
using OMS.Application.Shared.Validations;
using OMS.Infrastructure.Shared.Commands;
using OMS.Infrastructure.Shared.Queries.Queries;

namespace OMS.Bootstrapper.Shared;

public static class MediatorExtensions
{
    public static IServiceCollection AddMediatorRegistration(this IServiceCollection services)
    {
        //https://medium.com/@saisiva249/upgrading-mediatr-from-version-12-to-12-in-net-core-9dc7d59b464
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<PlaceOderRequest>();
        });

        //https://www.linkedin.com/pulse/advanced-features-mediatr-package-pipeline-behaviors
        // setup all the validators by scanning the assembly that the specific type belongs to
        services.AddValidatorsFromAssemblyContaining<PlaceOderRequest>();

        // register all the behaviors as pipeline behaviors, in the exacrt order we want to be executed
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPostProcessorBehavior<,>));

        services.AddTransient<ICommandExecutor, CommandExecutor>();
        services.AddTransient<IQueryExecutor, QueryExecutor>();

        return services;
    }
}