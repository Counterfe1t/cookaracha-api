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
        => await _dbContext.GroceryLists
            .AsNoTracking()
            .Include(gl => gl.Items)
            .ThenInclude(i => i.Product)
            .OrderBy(gl => gl.CreatedAt)
            .Select(gl => gl.AsDto())
            .Skip((query.PageNumber - 1) * query.PageSize)
            .Take(query.PageSize)
            .ToListAsync();
}