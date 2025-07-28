using Cookaracha.Core.Entities;
using Cookaracha.Core.Repositories;
using Cookaracha.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Cookaracha.Infrastructure.DAL.Repositories;

internal class ProductsRepository : IProductsRepository
{
    private readonly CookarachaDbContext _dbContext;

    public ProductsRepository(CookarachaDbContext dbContext)
        => _dbContext = dbContext;

    public async Task<IEnumerable<Product>> GetAllAsync()
        => await _dbContext.Products.ToListAsync();

    public async Task<Product?> GetAsync(EntityId id)
        => await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

    public async Task<Product?> GetAsync(ProductName name)
        => await _dbContext.Products.FirstOrDefaultAsync(p => p.Name == name);

    public async Task AddAsync(Product product)
    {
        _dbContext.Products.Add(product);

        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _dbContext.Products.Update(product);

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Product product)
    {
        _dbContext.Products.Remove(product);

        await _dbContext.SaveChangesAsync();
    }
}