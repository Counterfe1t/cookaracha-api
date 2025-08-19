using Cookaracha.Core.Entities;
using Cookaracha.Core.Repositories;
using Cookaracha.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Cookaracha.Infrastructure.DAL.Repositories;

internal sealed class UsersRepository : IUsersRepository
{
    private readonly CookarachaDbContext _dbContext;

    public UsersRepository(CookarachaDbContext dbContext)
        => _dbContext = dbContext;

    public async Task<User?> GetAsync(EntityId id)
        => await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

    public async Task<User?> GetAsync(Email email)
        => await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

    public async Task AddAsync(User user)
    {
        _dbContext.Users.Add(user);
        
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        _dbContext.Users.Update(user);

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(User user)
    {
        _dbContext.Users.Remove(user);

        await _dbContext.SaveChangesAsync();
    }
}