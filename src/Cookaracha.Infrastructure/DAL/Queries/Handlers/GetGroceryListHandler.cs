using Cookaracha.Application.Abstractions;
using Cookaracha.Application.DTO;
using Cookaracha.Core.Exceptions;
using Cookaracha.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Cookaracha.Infrastructure.DAL.Queries.Handlers;

internal sealed class GetGroceryListHandler : IQueryHandler<GetGroceryList, GroceryListDto>
{
    private readonly CookarachaDbContext _dbContext;

    public GetGroceryListHandler(CookarachaDbContext dbContext)
        => _dbContext = dbContext;

    public async Task<GroceryListDto> HandleAsync(GetGroceryList query)
    {
        var groceryList = await _dbContext.GroceryLists
            .AsNoTracking()
            .Include(gl => gl.Items)
            .ThenInclude(i => i.Product)
            .SingleOrDefaultAsync(gl => gl.Id == new EntityId(query.GroceryListId))
            ?? throw new GroceryListNotFoundException(query.GroceryListId);

        return groceryList.AsDto();
    }
}