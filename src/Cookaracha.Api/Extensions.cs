using Cookaracha.Infrastructure.Configuration;
using Microsoft.Extensions.Options;

namespace Cookaracha.Api;

internal static class Extensions
{
    public static WebApplication UseHome(this WebApplication app)
    {
        app.MapGet(string.Empty, (IOptions<AppOptions> options) => Results.Ok(options.Value.Name));

        return app;
    }
}