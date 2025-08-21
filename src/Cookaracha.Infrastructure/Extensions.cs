using Cookaracha.Core.Abstractions;
using Cookaracha.Infrastructure.Configuration;
using Cookaracha.Infrastructure.DAL;
using Cookaracha.Infrastructure.DAL.Queries;
using Cookaracha.Infrastructure.Logging;
using Cookaracha.Infrastructure.Middleware;
using Cookaracha.Infrastructure.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TimeProvider = Cookaracha.Infrastructure.Time.TimeProvider;

namespace Cookaracha.Infrastructure;

public static class Extensions
{
    private const string AppSectionName = "app";

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var options = configuration.GetOptions<AppOptions>(AppSectionName);
        services.Configure<AppOptions>(configuration.GetSection(AppSectionName));
        services.AddSingleton<ExceptionMiddleware>();
        services.AddSingleton<ITimeProvider, TimeProvider>();
        services.AddCustomLogging();
        services.AddDatabase(configuration);
        services.AddQueries();
        services.AddSecurity();

        services.AddSwaggerGen(swagger =>
        {
            swagger.EnableAnnotations();
            swagger.SwaggerDoc(options.Version, new()
            {
                Title = options.Name,
                Version = options.Version,
            });
        });

        return services;
    }

    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.MapControllers();

        return app;
    }

    public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
    {
        var options = new T();
        var section = configuration.GetSection(sectionName);
        section.Bind(options);

        return options;
    }
}