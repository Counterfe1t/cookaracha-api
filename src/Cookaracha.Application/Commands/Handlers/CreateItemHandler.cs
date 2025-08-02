using Cookaracha.Application.Abstractions;
using Cookaracha.Core.Abstractions;
using Cookaracha.Core.Repositories;

namespace Cookaracha.Application.Commands.Handlers;

internal sealed class CreateItemHandler : ICommandHandler<CreateItem>
{
    private readonly ITimeProvider _timeProvider;
    private readonly IItemsRepository _itemsRepository;

    public CreateItemHandler(ITimeProvider timeProvider, IItemsRepository itemsRepository)
    {
        _timeProvider = timeProvider;
        _itemsRepository = itemsRepository;
    }

    public async Task HandleAsync(CreateItem command)
        => await _itemsRepository.AddAsync(new(
            command.Id,
            _timeProvider.UtcNow,
            command.GroceryListId,
            command.ProductId,
            command.Name,
            command.Quantity,
            command.IsChecked));
}