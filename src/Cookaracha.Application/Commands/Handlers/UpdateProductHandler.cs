using Cookaracha.Application.Abstractions;
using Cookaracha.Core.Exceptions;
using Cookaracha.Core.Repositories;

namespace Cookaracha.Application.Commands.Handlers;

internal sealed class UpdateProductHandler : ICommandHandler<UpdateProduct>
{
    private readonly IProductsRepository _productsRepository;

    public UpdateProductHandler(IProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }

    public async Task HandleAsync(UpdateProduct command)
    {
        var product = await _productsRepository.GetAsync(command.Id)
            ?? throw new ProductNotFoundException(command.Id);

        product.ChangeProductName(command.Name);

        await _productsRepository.UpdateAsync(product);
    }
}