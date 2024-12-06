﻿using Cookaracha.Core.Entities;
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

    public async Task<IEnumerable<Product>> GetAllAsync() => await Task.FromResult(_products);
}