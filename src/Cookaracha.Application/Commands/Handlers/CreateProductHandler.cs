using Cookaracha.Application.Abstractions;
using Cookaracha.Core.Repositories;

namespace Cookaracha.Application.Commands.Handlers;

internal sealed class CreateProductHandler : ICommandHandler<CreateProduct>
{
    private readonly IProductsRepository _productsRepository;

    public CreateProductHandler(IProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }

    public async Task HandleAsync(CreateProduct command)
        => await _productsRepository.AddAsync(new(command.Id, command.Name));
}