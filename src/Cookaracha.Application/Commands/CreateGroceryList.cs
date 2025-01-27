using Cookaracha.Application.Abstractions;

namespace Cookaracha.Application.Commands;

public sealed record CreateGroceryList(Guid Id, string Name) : ICommand;