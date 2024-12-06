using Cookaracha.Core.Repositories;
using Cookaracha.Infrastructure.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Cookaracha.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        => services
            .AddSingleton<IProductsRepository, InMemoryProductsRepository>();
}