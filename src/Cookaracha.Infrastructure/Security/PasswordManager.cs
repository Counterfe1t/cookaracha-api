using Cookaracha.Application.Security;
using Cookaracha.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Cookaracha.Infrastructure.Security;

public sealed class PasswordManager : IPasswordManager
{
    private readonly IPasswordHasher<User> _passwordHasher;

    public PasswordManager(IPasswordHasher<User> passwordHasher)
        => _passwordHasher = passwordHasher;

    public string HashPassword(string password)
        => _passwordHasher.HashPassword(default!, password);

    public bool ValidatePassword(string password, string hashedPassword)
        => _passwordHasher.VerifyHashedPassword(default!, hashedPassword, password) is PasswordVerificationResult.Success;
}