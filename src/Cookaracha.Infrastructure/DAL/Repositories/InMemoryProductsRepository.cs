﻿using Cookaracha.Core.Entities;
using Cookaracha.Core.Repositories;
using Cookaracha.Core.ValueObjects;

namespace Cookaracha.Infrastructure.DAL.Repositories;

internal sealed class InMemoryProductsRepository : IProductsRepository
{
    private readonly List<Product> _products =
    [
        new(Guid.Parse("00000000-0000-0000-0000-000000000001"), "apple", DateTimeOffset.UtcNow),
        new(Guid.Parse("00000000-0000-0000-0000-000000000002"), "orange", DateTimeOffset.UtcNow),
        new(Guid.Parse("00000000-0000-0000-0000-000000000003"), "pear", DateTimeOffset.UtcNow),
        new(Guid.Parse("00000000-0000-0000-0000-000000000004"), "banana", DateTimeOffset.UtcNow),
        new(Guid.Parse("00000000-0000-0000-0000-000000000005"), "lemon", DateTimeOffset.UtcNow),
    ];

    public async Task<IEnumerable<Product>> GetAllAsync()
        => await Task.FromResult(_products);

    public async Task<Product?> GetAsync(EntityId id)
        => await Task.FromResult(_products.FirstOrDefault(p => p.Id == id));

    public async Task<Product?> GetAsync(ProductName name)
        => await Task.FromResult(_products.FirstOrDefault(p => p.Name == name));

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

    public Task DeleteAsync(Product product)
    {
        _products.Remove(product);

        return Task.CompletedTask;
    }
}