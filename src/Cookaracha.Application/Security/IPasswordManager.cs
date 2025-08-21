namespace Cookaracha.Application.Security;

public interface IPasswordManager
{
    /// <summary>
    /// Secure password using a hashing algorithm.
    /// </summary>
    /// <param name="password">Unsecured password.</param>
    /// <returns>Hashed password.</returns>
    string HashPassword(string password);
}