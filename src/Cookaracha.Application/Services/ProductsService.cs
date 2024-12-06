using Cookaracha.Application.Dtos;
using Cookaracha.Application.Interfaces;
using Cookaracha.Core.Repositories;

namespace Cookaracha.Application.Services;

public class ProductsService : IProductsService
{
    private readonly IProductsRepository _productsRepository;

    public ProductsService(IProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
        => (await _productsRepository.GetAllAsync()).Select(x => new ProductDto
        {
            Id = x.Id,
            Name = x.Name,
        });

    public async Task<ProductDto?> GetAsync(Guid id)
    {
        var product = await _productsRepository.GetAsync(id);
        if (product is null)
        {
            return default;
        }

        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name
        };
    }
}