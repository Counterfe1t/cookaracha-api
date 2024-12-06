using Cookaracha.Application.Interfaces;
using Cookaracha.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Cookaracha.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
        => services
            .AddScoped<IProductsService, ProductsService>();
}