using Cookaracha.Application.Abstractions;

namespace Cookaracha.Application.Commands;

public sealed record DeleteProduct(Guid Id) : ICommand;