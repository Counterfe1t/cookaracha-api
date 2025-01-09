using Microsoft.AspNetCore.Builder;
using Serilog;

namespace Cookaracha.Infrastructure.Logging;

public static class Extensions
{
    public static WebApplicationBuilder UseSerilog(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((context, configuration) =>
        {
            configuration.WriteTo.Console();
        });

        return builder;
    }
}