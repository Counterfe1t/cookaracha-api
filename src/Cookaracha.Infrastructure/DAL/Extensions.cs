using Cookaracha.Core.Repositories;
using Cookaracha.Infrastructure.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cookaracha.Infrastructure.DAL;

internal static class Extensions
{
    private const string DatabaseSectionName = "database";

    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var options = configuration.GetOptions<DatabaseOptions>(DatabaseSectionName);

        services.AddDbContext<CookarachaDbContext>(x => x.UseSqlServer(options.ConnectionString));
        services.AddScoped<IProductsRepository, ProductsRepository>();
        services.AddScoped<IGroceryListsRepository, GroceryListsRepository>();
        services.AddHostedService<DatabaseInitializer>();

        return services;
    }
}