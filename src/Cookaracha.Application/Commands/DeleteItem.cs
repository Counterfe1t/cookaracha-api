using Cookaracha.Application.Abstractions;

namespace Cookaracha.Application.Commands;

public sealed record DeleteItem(Guid Id) : ICommand;