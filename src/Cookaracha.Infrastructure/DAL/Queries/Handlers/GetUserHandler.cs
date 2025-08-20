using Cookaracha.Application.Abstractions;
using Cookaracha.Application.DTO;
using Cookaracha.Core.Exceptions;
using Cookaracha.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Cookaracha.Infrastructure.DAL.Queries.Handlers;

internal sealed class GetUserHandler : IQueryHandler<GetUser, UserDto>
{
    private readonly CookarachaDbContext _dbContext;

    public GetUserHandler(CookarachaDbContext dbContext)
        => _dbContext = dbContext;

    public async Task<UserDto> HandleAsync(GetUser query)
    {
        var user = await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == new EntityId(query.Id))
            ?? throw new UserNotFoundException(query.Id);

        return user.AsDto();
    }
}