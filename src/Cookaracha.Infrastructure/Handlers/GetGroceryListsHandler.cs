using Cookaracha.Application.Abstractions;
using Cookaracha.Application.DTO;
using Cookaracha.Application.Queries;
using Cookaracha.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace Cookaracha.Infrastructure.Handlers;

internal sealed class GetGroceryListsHandler : IQueryHandler<GetGroceryLists, IEnumerable<GroceryListDto>>
{
    private readonly CookarachaDbContext _dbContext;

    public GetGroceryListsHandler(CookarachaDbContext dbContext)
        => _dbContext = dbContext;

    public async Task<IEnumerable<GroceryListDto>> HandleAsync(GetGroceryLists query)
    {
        var groceryLists = await _dbContext.GroceryLists
            .AsNoTracking()
            .Include(gl => gl.Items)
            .ThenInclude(i => i.Product)
            .ToListAsync();

        return groceryLists.Select(gl => gl.AsDto());
    }
}