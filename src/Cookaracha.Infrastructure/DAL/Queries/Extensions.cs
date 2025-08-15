using Cookaracha.Application.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Cookaracha.Infrastructure.DAL.Queries;

internal static class Extensions
{
    public static IServiceCollection AddQueries(this IServiceCollection services)
    {
        services.Scan(s => s.FromAssemblies(typeof(Extensions).Assembly)
            .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}