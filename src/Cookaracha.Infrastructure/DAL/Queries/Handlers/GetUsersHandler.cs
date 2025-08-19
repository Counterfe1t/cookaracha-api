using Cookaracha.Application.Abstractions;
using Cookaracha.Application.DTO;
using Microsoft.EntityFrameworkCore;

namespace Cookaracha.Infrastructure.DAL.Queries.Handlers;

internal sealed class GetUsersHandler : IQueryHandler<GetUsers, IEnumerable<UserDto>>
{
    private readonly CookarachaDbContext _dbContext;

    public GetUsersHandler(CookarachaDbContext dbContext)
        => _dbContext = dbContext;

    public async Task<IEnumerable<UserDto>> HandleAsync(GetUsers query)
        => await _dbContext.Users
            .AsNoTracking()
            .OrderBy(u => u.CreatedAt)
            .Select(u => u.AsDto())
            .Skip((query.PageNumber - 1) * query.PageSize)
            .Take(query.PageSize)
            .ToListAsync();
}