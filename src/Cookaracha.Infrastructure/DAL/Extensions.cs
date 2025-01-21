using Cookaracha.Core.Repositories;
using Cookaracha.Infrastructure.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Cookaracha.Infrastructure.DAL;

internal static class Extensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        services.AddSingleton<IProductsRepository, InMemoryProductsRepository>();
        services.AddSingleton<IGroceryListsRepository, InMemoryGroceryListsRepository>();

        return services;
    }
}