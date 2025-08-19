using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Cookaracha.Infrastructure.DAL;

internal sealed class DatabaseInitializer : IHostedService
{
    private IServiceProvider _serviceProvider;

    public DatabaseInitializer(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        // Apply all necessary migrations on application start-up.
        using var scope = _serviceProvider.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<CookarachaDbContext>();
        dbContext.Database.Migrate();

        var products = await dbContext.Products.ToListAsync(cancellationToken);
        if (products.Count == 0)
        {
            // TODO: Initialize products table with JSON file.
            products =
            [
                new(Guid.Parse("00000000-0000-0000-0000-000000000001"), "apple", DateTimeOffset.UtcNow),
                new(Guid.Parse("00000000-0000-0000-0000-000000000002"), "orange", DateTimeOffset.UtcNow),
                new(Guid.Parse("00000000-0000-0000-0000-000000000003"), "pear", DateTimeOffset.UtcNow),
                new(Guid.Parse("00000000-0000-0000-0000-000000000004"), "banana", DateTimeOffset.UtcNow),
                new(Guid.Parse("00000000-0000-0000-0000-000000000005"), "lemon", DateTimeOffset.UtcNow),
            ];

            await dbContext.Products.AddRangeAsync(products, cancellationToken);
        }

        var users = await dbContext.Users.ToListAsync(cancellationToken);
        if (users.Count == 0)
        {
            await dbContext.Users.AddAsync(new(
                Guid.Parse("00000000-0000-0000-0000-000000000001"),
                DateTimeOffset.UtcNow,
                "admin",
                "admin@cookaracha.dev",
                "password"), cancellationToken);
        }

        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
        => throw new NotImplementedException();
}