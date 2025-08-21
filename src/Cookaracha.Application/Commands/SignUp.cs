using Cookaracha.Application.Abstractions;

namespace Cookaracha.Application.Commands;

public sealed record SignUp(
    Guid Id,
    string Name,
    string Email,
    string Password) : ICommand;