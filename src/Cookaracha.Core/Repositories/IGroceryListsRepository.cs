using Cookaracha.Core.Entities;

namespace Cookaracha.Core.Repositories;

public interface IGroceryListsRepository
{
    /// <summary>
    /// Get all grocery lists.
    /// </summary>
    /// <returns>Collection of <see cref="GroceryList"/> objects.</returns>
    Task<IEnumerable<GroceryList>> GetAllAsync();

    /// <summary>
    /// Get grocery list by ID.
    /// </summary>
    /// <param name="id">Grocery list ID.</param>
    /// <returns><see cref="GroceryList"/> object.</returns>
    Task<GroceryList?> GetAsync(Guid id);

    /// <summary>
    /// Add grocery list.
    /// </summary>
    /// <param name="groceryList"><see cref="GroceryList"/> object.</param>
    Task AddAsync(GroceryList groceryList);

    /// <summary>
    /// Update grocery list.
    /// </summary>
    /// <param name="groceryList"><see cref="GroceryList"/> object.</param>
    Task UpdateAsync(GroceryList groceryList);

    /// <summary>
    /// Delete grocery list.
    /// </summary>
    /// <param name="groceryList"><see cref="GroceryList"/> object.</param>
    Task DeleteAsync(GroceryList groceryList);
}