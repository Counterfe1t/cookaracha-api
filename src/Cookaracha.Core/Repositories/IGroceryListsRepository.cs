using Cookaracha.Core.Entities;

namespace Cookaracha.Core.Repositories;

public interface IGroceryListsRepository
{
    Task<IEnumerable<GroceryList>> GetAllAsync();
    Task<GroceryList?> GetAsync(Guid id);
    Task AddAsync(GroceryList groceryList);
}