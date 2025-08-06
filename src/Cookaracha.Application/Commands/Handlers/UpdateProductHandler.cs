using Cookaracha.Application.Abstractions;
using Cookaracha.Core.Abstractions;
using Cookaracha.Core.Exceptions;
using Cookaracha.Core.Repositories;

namespace Cookaracha.Application.Commands.Handlers;

internal sealed class UpdateProductHandler : ICommandHandler<UpdateProduct>
{
    private readonly ITimeProvider _timeProvider;
    private readonly IProductsRepository _productsRepository;

    public UpdateProductHandler(ITimeProvider timeProvider, IProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
        _timeProvider = timeProvider;
    }

    public async Task HandleAsync(UpdateProduct command)
    {
        var product = await _productsRepository.GetAsync(command.Id)
            ?? throw new ProductNotFoundException(command.Id);

        product.ChangeProductName(command.Name);
        product.ChangeModifiedAt(_timeProvider.UtcNow);

        await _productsRepository.UpdateAsync(product);
    }
}