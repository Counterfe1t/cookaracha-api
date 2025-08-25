using Cookaracha.Application.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cookaracha.Infrastructure.Auth;

internal static class Extensions
{
    private const string AuthSectionName = "auth";

    public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        //services.Configure<AuthOptions>(configuration.GetRequiredSection(SectionName));
        //var options = configuration.GetOptions<AuthOptions>(SectionName);

        services.AddScoped<ITokenStorage, HttpContextTokenStorage>();

        return services;
    }
}