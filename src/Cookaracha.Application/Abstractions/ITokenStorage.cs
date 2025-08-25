using Cookaracha.Application.DTO;

namespace Cookaracha.Application.Abstractions;

public interface ITokenStorage
{
    /// <summary>
    /// Store JWT in the current http context.
    /// </summary>
    /// <param name="jwt">JSON Web Token.</param>
    void Set(JwtDto jwt);

    /// <summary>
    /// Fetch JWT from the current http context.
    /// </summary>
    /// <returns><see cref="JwtDto" /> object model or null if there is none stored in the http context.</returns>
    JwtDto? Get();
}