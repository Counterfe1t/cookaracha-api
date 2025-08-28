using Cookaracha.Application.DTO;
using Cookaracha.Application.Security;
using Cookaracha.Core.Abstractions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Cookaracha.Infrastructure.Auth;

internal sealed class Authenticator : IAuthenticator
{
    private readonly ITimeProvider _timeProvider;

    private readonly SigningCredentials _signingCredentials;
    private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler = new();

    private readonly string _issuer;
    private readonly string _audience;
    private readonly TimeSpan _expiry;

    public Authenticator(ITimeProvider timeProvider, IOptions<AuthOptions> options)
    {
        _timeProvider = timeProvider;
        _issuer = options.Value.Issuer ?? "cookaracha-issuer";
        _audience = options.Value.Audience ?? "cookaracha-audience";
        _expiry = options.Value.Expiry ?? TimeSpan.FromHours(1);
        _signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.SigningKey)),
            SecurityAlgorithms.HmacSha256);
    }

    public JwtDto CreateToken(Guid userId)
    {
        var now = _timeProvider.UtcNow.ToLocalTime();
        var expiresAt = now.Add(_expiry);

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
        };

        var jwt = new JwtSecurityToken(
            _issuer,
            _audience,
            claims,
            now.DateTime,
            expiresAt.DateTime,
            _signingCredentials);

        return new() { AccessToken = _jwtSecurityTokenHandler.WriteToken(jwt) };
    }
}