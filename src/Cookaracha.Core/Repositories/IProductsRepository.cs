using Cookaracha.Core.Entities;

namespace Cookaracha.Core.Repositories;

public interface IProductsRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetAsync(Guid id);
}