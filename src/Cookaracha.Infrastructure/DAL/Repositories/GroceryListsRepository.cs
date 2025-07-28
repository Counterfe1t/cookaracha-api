using Cookaracha.Core.Entities;
using Cookaracha.Core.Repositories;
using Cookaracha.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Cookaracha.Infrastructure.DAL.Repositories;

internal sealed class GroceryListsRepository : IGroceryListsRepository
{
    private readonly CookarachaDbContext _dbContext;

    public GroceryListsRepository(CookarachaDbContext dbContext)
        => _dbContext = dbContext;

    public async Task<IEnumerable<GroceryList>> GetAllAsync()
        => await _dbContext.GroceryLists
            .Include(gl => gl.Items)
            .ThenInclude(i => i.Product)
            .ToListAsync();

    public async Task<GroceryList?> GetAsync(EntityId id)
        => await _dbContext.GroceryLists
            .Include(gl => gl.Items)
            .ThenInclude(i => i.Product)
            .FirstOrDefaultAsync(gl => gl.Id == id);

    public async Task AddAsync(GroceryList groceryList)
    {
        _dbContext.GroceryLists.Add(groceryList);

        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(GroceryList groceryList)
    {
        _dbContext.GroceryLists.Update(groceryList);

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(GroceryList groceryList)
    {
        _dbContext.Remove(groceryList);

        await _dbContext.SaveChangesAsync();
    }
}