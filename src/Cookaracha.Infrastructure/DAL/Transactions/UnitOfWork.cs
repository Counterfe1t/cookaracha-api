namespace Cookaracha.Infrastructure.DAL.Transactions;

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly CookarachaDbContext _dbContext;

    public UnitOfWork(CookarachaDbContext dbContext)
        => _dbContext = dbContext;

    public async Task ExecuteAsync(Func<Task> action)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync();

        try
        {
            await action();
            await _dbContext.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}