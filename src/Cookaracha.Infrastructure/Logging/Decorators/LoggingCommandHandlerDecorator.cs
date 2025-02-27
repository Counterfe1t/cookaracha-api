using Cookaracha.Application.Abstractions;
using Humanizer;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Cookaracha.Infrastructure.Logging.Decorators;

internal sealed class LoggingCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : class, ICommand
{
    private readonly ILogger<ICommandHandler<TCommand>> _logger;
    private readonly ICommandHandler<TCommand> _commandHandler;

    public LoggingCommandHandlerDecorator(
        ILogger<ICommandHandler<TCommand>> logger,
        ICommandHandler<TCommand> commandHandler)
    {
        _logger = logger;
        _commandHandler = commandHandler;
    }

    public async Task HandleAsync(TCommand command)
    {
        var commandName = typeof(TCommand).Name.Underscore();
        var stopwatch = new Stopwatch();

        stopwatch.Start();
        _logger.LogInformation("started handling command: {CommandName}", commandName);

        await _commandHandler.HandleAsync(command);

        stopwatch.Stop();
        _logger.LogInformation("completed handling command: {CommandName} in {Elapsed}", commandName, stopwatch.Elapsed);
    }
}