using Cookaracha.Application.Commands;
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
            return default;

        return new()
        {
            Id = product.Id,
            Name = product.Name
        };
    }

    public async Task CreateProductAsync(CreateProduct command)
        => await _productsRepository.AddAsync(new(command.Id, command.Name));

    public async Task<bool> UpdateProductAsync(UpdateProduct command)
    {
        var product = await _productsRepository.GetAsync(command.Id);
        if (product is null)
            return false;

        product = new(command.Id, command.Name);

        await _productsRepository.UpdateAsync(product);

        return true;
    }

    public async Task<bool> DeleteProductAsync(DeleteProduct command)
    {
        var product = await _productsRepository.GetAsync(command.Id);
        if (product is null)
            return false;

        await _productsRepository.DeleteAsync(product);

        return true;
    }
}