using Cookaracha.Infrastructure.Configuration;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Annotations;

namespace Cookaracha.Api;

internal static class Extensions
{
    // TODO: Return API name and health check
    public static WebApplication MapHomeEndpoint(this WebApplication app)
    {
        app.MapGet("/api", (IOptions<AppOptions> options) => Results.Ok(options.Value.Name))
            .WithMetadata(new SwaggerOperationAttribute("Get API name."));

        return app;
    }
}