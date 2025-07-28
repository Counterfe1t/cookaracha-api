using Cookaracha.Application.Abstractions;
using Cookaracha.Application.DTO;
using Cookaracha.Application.Queries;
using Cookaracha.Core.Exceptions;
using Cookaracha.Core.ValueObjects;
using Cookaracha.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace Cookaracha.Infrastructure.Handlers;

internal sealed class GetProductHandler : IQueryHandler<GetProduct, ProductDto>
{
    private readonly CookarachaDbContext _dbContext;

    public GetProductHandler(CookarachaDbContext dbContext)
        => _dbContext = dbContext;

    public async Task<ProductDto> HandleAsync(GetProduct query)
    {
        var product = await _dbContext.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == new EntityId(query.ProductId))
            ?? throw new ProductNotFoundException(query.ProductId);

        return product.AsDto();
    }
}