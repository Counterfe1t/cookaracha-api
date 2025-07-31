using Cookaracha.Application.Abstractions;
using Cookaracha.Application.DTO;
using Cookaracha.Application.Queries;
using Cookaracha.Core.Exceptions;
using Cookaracha.Core.ValueObjects;
using Cookaracha.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace Cookaracha.Infrastructure.Handlers;

internal sealed class GetItemHandler : IQueryHandler<GetItem, ItemDto>
{
    private readonly CookarachaDbContext _dbContext;

    public GetItemHandler(CookarachaDbContext dbContext)
        => _dbContext = dbContext;

    public async Task<ItemDto> HandleAsync(GetItem query)
    {
        var item = await _dbContext.Items
            .AsNoTracking()
            .SingleOrDefaultAsync(i => i.Id == new EntityId(query.Id))
            ?? throw new ItemNotFoundException(query.Id);

        return item.AsDto();
    }
}