using Cookaracha.Core.Entities;
using Cookaracha.Core.ValueObjects;

namespace Cookaracha.Core.Repositories;

public interface IProductsRepository
{
    /// <summary>
    /// Get all products.
    /// </summary>
    /// <returns>Collection of <see cref="Product"/> objects.</returns>
    Task<IEnumerable<Product>> GetAllAsync();

    /// <summary>
    /// Get product by ID.
    /// </summary>
    /// <param name="id">Product ID.</param>
    /// <returns><see cref="Product"/> object.</returns>
    Task<Product?> GetAsync(EntityId id);

    /// <summary>
    /// Get product by name.
    /// </summary>
    /// <param name="name">Product name.</param>
    /// <returns><see cref="Product"/> object.</returns>
    Task<Product?> GetAsync(ProductName name);

    /// <summary>
    /// Add product.
    /// </summary>
    /// <param name="product"><see cref="Product"/> object.</param>
    Task AddAsync(Product product);

    /// <summary>
    /// Update product.
    /// </summary>
    /// <param name="product"><see cref="Product"/> object.</param>
    Task UpdateAsync(Product product);

    /// <summary>
    /// Delete product.
    /// </summary>
    /// <param name="product"><see cref="Product"/> object.</param>
    Task DeleteAsync(Product product);
}