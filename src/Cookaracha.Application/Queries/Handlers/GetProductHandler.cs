using Cookaracha.Application.Abstractions;
using Cookaracha.Application.DTO;
using Cookaracha.Application.Exceptions;
using Cookaracha.Core.Repositories;

namespace Cookaracha.Application.Queries.Handlers;

internal sealed class GetProductHandler : IQueryHandler<GetProduct, ProductDto>
{
    private readonly IProductsRepository _productsRepository;

    public GetProductHandler(IProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }

    public async Task<ProductDto> HandleAsync(GetProduct command)
    {
        var product = await _productsRepository.GetAsync(command.ProductId)
            ?? throw new ProductNotFoundException(command.ProductId);
        
        return new()
        {
            Id = product.Id,
            Name = product.Name
        };
    }
}