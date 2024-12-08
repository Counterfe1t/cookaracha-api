using Cookaracha.Core.Entities;

namespace Cookaracha.Core.Repositories;

public interface IProductsRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetAsync(Guid id);
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(Product product);
}