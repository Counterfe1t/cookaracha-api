using Cookaracha.Core.Entities;
using Cookaracha.Core.ValueObjects;

namespace Cookaracha.Core.Repositories;

public interface IItemsRepository
{
    /// <summary>
    /// Get item by ID
    /// </summary>
    /// <param name="id">Unique item identifier.</param>
    /// <returns><see cref="Item" /> entity model.</returns>
    Task<Item?> GetAsync(EntityId id);

    /// <summary>
    /// Add item.
    /// </summary>
    /// <param name="item"><see cref="Item" /> entity model.</param>
    Task AddAsync(Item item);

    /// <summary>
    /// Update item.
    /// </summary>
    /// <param name="item"><see cref="Item" /> entity model.</param>
    Task UpdateAsync(Item item);

    /// <summary>
    /// Delete item.
    /// </summary>
    /// <param name="item"><see cref="Item" /> entity model.</param>
    Task DeleteAsync(Item item);
}