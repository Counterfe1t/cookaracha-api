using Cookaracha.Infrastructure.Configuration;
using Cookaracha.Infrastructure.DAL;
using Cookaracha.Infrastructure.Logging;
using Cookaracha.Infrastructure.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cookaracha.Infrastructure;

public static class Extensions
{
    private const string AppSectionName = "app";

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AppOptions>(configuration.GetSection(AppSectionName));
        services.AddSingleton<ExceptionMiddleware>();
        services.AddCustomLogging();
        services.AddDatabase();

        return services;
    }

    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
        app.MapControllers();

        return app;
    }
}