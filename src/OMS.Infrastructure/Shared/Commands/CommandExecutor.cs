using MediatR;
using OMS.Application.Shared.Commands.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Infrastructure.Shared.Commands;

public class CommandExecutor : ICommandExecutor
{
    private readonly IMediator _mediator;

    public CommandExecutor(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Execute(ICommand command)
    {
        await _mediator.Send(command);
    }

    public async Task<TResult> Execute<TResult>(ICommand<TResult> command)
    {
        return await _mediator.Send(command);
    }
}