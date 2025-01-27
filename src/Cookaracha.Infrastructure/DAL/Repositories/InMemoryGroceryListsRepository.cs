using Cookaracha.Core.Entities;
using Cookaracha.Core.Repositories;

namespace Cookaracha.Infrastructure.DAL.Repositories;

internal sealed class InMemoryGroceryListsRepository : IGroceryListsRepository
{
    private readonly List<GroceryList> _groceryLists =
    [
        new(Guid.Parse("00000000-0000-0000-0000-000000000001"), "grocery_list_1"),
        new(Guid.Parse("00000000-0000-0000-0000-000000000002"), "grocery_list_2"),
        new(Guid.Parse("00000000-0000-0000-0000-000000000003"), "grocery_list_3"),
        new(Guid.Parse("00000000-0000-0000-0000-000000000004"), "grocery_list_4"),
        new(Guid.Parse("00000000-0000-0000-0000-000000000005"), "grocery_list_5"),
    ];

    public async Task<IEnumerable<GroceryList>> GetAllAsync()
        => await Task.FromResult(_groceryLists);

    public async Task<GroceryList?> GetAsync(Guid id)
        => await Task.FromResult(_groceryLists.FirstOrDefault(gl => gl.Id == id));

    public Task AddAsync(GroceryList groceryList)
    {
        _groceryLists.Add(groceryList);

        return Task.CompletedTask;
    }

    public Task UpdateAsync(GroceryList groceryList)
    {
        // Update grocery list

        return Task.CompletedTask;
    }

    public Task DeleteAsync(GroceryList groceryList)
    {
        _groceryLists.Remove(groceryList);

        return Task.CompletedTask;
    }
}