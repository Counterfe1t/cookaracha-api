using Cookaracha.Application.Abstractions;

namespace Cookaracha.Application.Commands;

public sealed record SignIn(string Email, string Password) : ICommand;