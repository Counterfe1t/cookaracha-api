using Cookaracha.Core.Entities;
using Cookaracha.Core.Repositories;

namespace Cookaracha.Infrastructure.DAL.Repositories;

internal sealed class InMemoryGroceryListsRepository : IGroceryListsRepository
{
    private readonly List<GroceryList> _groceryLists =
    [
        new(Guid.Parse("00000000-0000-0000-0000-000000000001")),
        new(Guid.Parse("00000000-0000-0000-0000-000000000002")),
        new(Guid.Parse("00000000-0000-0000-0000-000000000003")),
        new(Guid.Parse("00000000-0000-0000-0000-000000000004")),
        new(Guid.Parse("00000000-0000-0000-0000-000000000005")),
    ];

    public async Task<IEnumerable<GroceryList>> GetAllAsync()
        => await Task.FromResult(_groceryLists);

    public async Task<GroceryList?> GetAsync(Guid id)
        => await Task.FromResult(_groceryLists.FirstOrDefault(gl => gl.Id.Value == id));
}