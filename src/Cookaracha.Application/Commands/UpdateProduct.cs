using Cookaracha.Application.Abstractions;

namespace Cookaracha.Application.Commands;

public sealed record UpdateProduct(Guid Id, string Name) : ICommand;