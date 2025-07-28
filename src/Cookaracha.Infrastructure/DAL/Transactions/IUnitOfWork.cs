namespace Cookaracha.Infrastructure.DAL.Transactions;

internal interface IUnitOfWork
{
    /// <summary>
    /// Execute action as a database transaction.
    /// </summary>
    /// <param name="action">The command to be executed on database.</param>
    Task ExecuteAsync(Func<Task> action);
}