using Cookaracha.Application.DTO;

namespace Cookaracha.Application.Security;

public interface IAuthenticator
{
    /// <summary>
    /// Create JSON Web Token for the specified user.
    /// </summary>
    /// <param name="userId">Unique user identifier.</param>
    /// <returns><see cref="JwtDto" /> object model.</returns>
    JwtDto CreateToken(Guid userId);
}