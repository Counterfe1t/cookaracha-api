namespace Cookaracha.Application.Security;

public interface IPasswordManager
{
    /// <summary>
    /// Secure password using a hashing algorithm.
    /// </summary>
    /// <param name="password">Unsecured password.</param>
    /// <returns>Hashed password.</returns>
    string HashPassword(string password);

    /// <summary>
    /// Validate if the provided password matches the hashed password.
    /// </summary>
    /// <param name="password">Unsecured password provided by user.</param>
    /// <param name="hashedPassword">Secured password.</param>
    /// <returns></returns>
    bool ValidatePassword(string password, string hashedPassword);
}