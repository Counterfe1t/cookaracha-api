namespace Cookaracha.Application.Abstractions;

public interface IQueryHandler<IQuery, TResult> where IQuery : class, IQuery<TResult>
{
    Task<TResult> HandleAsync(IQuery command);
}