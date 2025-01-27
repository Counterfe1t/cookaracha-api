using Cookaracha.Application.Abstractions;
using Cookaracha.Application.Exceptions;
using Cookaracha.Core.Repositories;

namespace Cookaracha.Application.Commands.Handlers;

internal class DeleteProductHandler : ICommandHandler<DeleteProduct>
{
    private readonly IProductsRepository _productsRepository;

    public DeleteProductHandler(IProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }

    public async Task HandleAsync(DeleteProduct command)
    {
        var product = await _productsRepository.GetAsync(command.Id)
            ?? throw new ProductNotFoundException(command.Id);

        await _productsRepository.DeleteAsync(product);
    }
}