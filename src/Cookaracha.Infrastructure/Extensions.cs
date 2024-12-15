using Cookaracha.Core.Repositories;
using Cookaracha.Infrastructure.Configuration;
using Cookaracha.Infrastructure.DAL.Repositories;
using Cookaracha.Infrastructure.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cookaracha.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var section = configuration.GetSection("app");

        services.Configure<AppOptions>(section);
        services.AddSingleton<ExceptionMiddleware>();
        services.AddSingleton<IProductsRepository, InMemoryProductsRepository>();

        return services;
    }

    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
        app.MapControllers();

        return app;
    }
}