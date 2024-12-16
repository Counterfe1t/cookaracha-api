using Cookaracha.Application.Abstractions;
using Cookaracha.Application.DTO;
using Cookaracha.Core.Repositories;

namespace Cookaracha.Application.Queries.Handlers;

internal sealed class GetProductsHandler : IQueryHandler<GetProducts, IEnumerable<ProductDto>>
{
    private readonly IProductsRepository _productsRepository;

    public GetProductsHandler(IProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }

    public async Task<IEnumerable<ProductDto>> HandleAsync(GetProducts command)
    {
        var products = await _productsRepository.GetAllAsync();
        
        return products.Select(x => new ProductDto
        {
            Id = x.Id,
            Name = x.Name,
        });
    }
}