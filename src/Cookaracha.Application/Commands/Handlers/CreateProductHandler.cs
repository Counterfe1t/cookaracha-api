﻿using Cookaracha.Application.Abstractions;
using Cookaracha.Core.Abstractions;
using Cookaracha.Core.Repositories;
using Cookaracha.Core.ValueObjects;

namespace Cookaracha.Application.Commands.Handlers;

internal sealed class CreateProductHandler : ICommandHandler<CreateProduct>
{
    private readonly ITimeProvider _timeProvider;
    private readonly IProductsRepository _productsRepository;

    public CreateProductHandler(ITimeProvider timeProvider, IProductsRepository productsRepository)
    {
        _timeProvider = timeProvider;
        _productsRepository = productsRepository;
    }

    public async Task HandleAsync(CreateProduct command)
        => await _productsRepository.AddAsync(new(command.Id, command.Name, new Date(_timeProvider.UtcNow)));
}