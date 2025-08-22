using Cookaracha.Application.Abstractions;

namespace Cookaracha.Application.Commands;

public sealed record DeleteUser(Guid Id) : ICommand;