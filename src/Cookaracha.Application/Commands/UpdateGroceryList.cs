using Cookaracha.Application.Abstractions;

namespace Cookaracha.Application.Commands;

public sealed record UpdateGroceryList(Guid Id) : ICommand;