using Cookaracha.Core.Entities;
using Cookaracha.Core.Repositories;

namespace Cookaracha.Infrastructure.DAL.Repositories;

internal class InMemoryProductsRepository : IProductsRepository
{
    private readonly List<Product> _products =
    [
        new(Guid.Parse("00000000-0000-0000-0000-000000000001"), "Apple"),
        new(Guid.Parse("00000000-0000-0000-0000-000000000002"), "Orange"),
        new(Guid.Parse("00000000-0000-0000-0000-000000000003"), "Pear"),
        new(Guid.Parse("00000000-0000-0000-0000-000000000004"), "Banana"),
        new(Guid.Parse("00000000-0000-0000-0000-000000000005"), "Lemon"),
    ];

    public async Task<IEnumerable<Product>> GetAllAsync()
        => await Task.FromResult(_products);

    public async Task<Product?> GetAsync(Guid id)
        => await Task.FromResult(_products.FirstOrDefault(x => x.Id == id));

    public Task AddAsync(Product product)
    {
        _products.Add(product);

        return Task.CompletedTask;
    }

    public Task UpdateAsync(Product product)
    {
        // Update product
        return Task.CompletedTask;
    }
}