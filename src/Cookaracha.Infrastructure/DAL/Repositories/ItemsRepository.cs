using Cookaracha.Core.Entities;
using Cookaracha.Core.Repositories;
using Cookaracha.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Cookaracha.Infrastructure.DAL.Repositories;

internal sealed class ItemsRepository : IItemsRepository
{
    private readonly CookarachaDbContext _dbContext;

    public ItemsRepository(CookarachaDbContext dbContext)
        => _dbContext = dbContext;

    public async Task<Item?> GetAsync(EntityId id)
        => await _dbContext.Items.FirstOrDefaultAsync(i => i.Id == id);

    public async Task AddAsync(Item item)
    {
        _dbContext.Items.Add(item);

        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Item item)
    {
        _dbContext.Items.Update(item);

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Item item)
    {
        _dbContext.Items.Remove(item);

        await _dbContext.SaveChangesAsync();
    }
}