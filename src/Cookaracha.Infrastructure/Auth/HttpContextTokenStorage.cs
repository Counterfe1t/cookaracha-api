using Cookaracha.Application.Abstractions;
using Cookaracha.Application.DTO;
using Microsoft.AspNetCore.Http;

namespace Cookaracha.Infrastructure.Auth;

internal sealed class HttpContextTokenStorage : ITokenStorage
{
    private const string TokenKey = "jwt";

    private readonly IHttpContextAccessor _httpContextAccessor;

    public HttpContextTokenStorage(IHttpContextAccessor httpContextAccessor)
        => _httpContextAccessor = httpContextAccessor;

    public void Set(JwtDto jwt)
        => _httpContextAccessor.HttpContext?.Items.TryAdd(TokenKey, jwt);

    public JwtDto? Get()
    {
        if (_httpContextAccessor.HttpContext is null)
            return null;

        if (!_httpContextAccessor.HttpContext.Items.TryGetValue(TokenKey, out var jwt))
            return null;

        return (JwtDto?)jwt;
    }
}