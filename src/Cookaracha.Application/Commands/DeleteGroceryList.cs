using Cookaracha.Application.Abstractions;
using Cookaracha.Application.Exceptions;
using Cookaracha.Core.Repositories;

namespace Cookaracha.Application.Commands;

public sealed record DeleteGroceryList(Guid Id) : ICommand;