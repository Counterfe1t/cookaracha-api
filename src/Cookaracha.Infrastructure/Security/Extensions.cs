using Cookaracha.Application.Security;
using Cookaracha.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Cookaracha.Infrastructure.Security;

internal static class Extensions
{
    public static IServiceCollection AddSecurity(this IServiceCollection services)
    {
        services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();
        services.AddSingleton<IPasswordManager, PasswordManager>();

        return services;
    }
}