using Cookaracha.Application.Abstractions;

namespace Cookaracha.Application.Commands;

public record UpdateUser(
    Guid Id,
    string? Name,
    string? Email,
    string? Password) : ICommand;