using Cookaracha.Application.Abstractions;

namespace Cookaracha.Application.Commands;

public sealed record DeleteGroceryList(Guid Id) : ICommand;