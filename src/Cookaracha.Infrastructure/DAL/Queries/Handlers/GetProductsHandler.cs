using Cookaracha.Application.Abstractions;
using Cookaracha.Application.DTO;
using Microsoft.EntityFrameworkCore;

namespace Cookaracha.Infrastructure.DAL.Queries.Handlers;

internal sealed class GetProductsHandler : IQueryHandler<GetProducts, IEnumerable<ProductDto>>
{
    private readonly CookarachaDbContext _dbContext;

    public GetProductsHandler(CookarachaDbContext dbContext)
        => _dbContext = dbContext;

    public async Task<IEnumerable<ProductDto>> HandleAsync(GetProducts query)
        => await _dbContext.Products
            .AsNoTracking()
            .OrderBy(p => p.Name)
            .Select(p => p.AsDto())
            .Skip((query.PageNumber - 1) * query.PageSize)
            .Take(query.PageSize)
            .ToListAsync();
}