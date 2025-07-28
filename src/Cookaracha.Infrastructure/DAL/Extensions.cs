using Cookaracha.Application.Abstractions;
using Cookaracha.Core.Repositories;
using Cookaracha.Infrastructure.DAL.Decorators;
using Cookaracha.Infrastructure.DAL.Repositories;
using Cookaracha.Infrastructure.DAL.Transactions;
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

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.TryDecorate(typeof(ICommandHandler<>), typeof(UnitOfWorkCommandHandlerDecorator<>));

        services.AddScoped<IProductsRepository, ProductsRepository>();
        services.AddScoped<IGroceryListsRepository, GroceryListsRepository>();
        services.AddHostedService<DatabaseInitializer>();

        return services;
    }
}