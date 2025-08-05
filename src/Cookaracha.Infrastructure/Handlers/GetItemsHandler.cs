using Cookaracha.Application.Abstractions;
using Cookaracha.Application.DTO;
using Cookaracha.Application.Queries;
using Cookaracha.Core.ValueObjects;
using Cookaracha.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace Cookaracha.Infrastructure.Handlers;

internal class GetItemsHandler : IQueryHandler<GetItems, IEnumerable<ItemDto>>
{
    private readonly CookarachaDbContext _dbContext;

    public GetItemsHandler(CookarachaDbContext dbContext)
        => _dbContext = dbContext;

    public async Task<IEnumerable<ItemDto>> HandleAsync(GetItems query)
        => await _dbContext.Items
            .AsNoTracking()
            .Where(i => i.GroceryListId == new EntityId(query.GroceryListId))
            .OrderBy(i => i.CreatedAt)
            .Select(i => i.AsDto())
            .Skip((query.PageNumber - 1) * query.PageSize)
            .Take(query.PageSize)
            .ToListAsync();
}