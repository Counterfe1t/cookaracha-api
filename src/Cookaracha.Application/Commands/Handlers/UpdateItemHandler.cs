using Cookaracha.Application.Abstractions;
using Cookaracha.Core.Abstractions;
using Cookaracha.Core.Exceptions;
using Cookaracha.Core.Repositories;

namespace Cookaracha.Application.Commands.Handlers;

internal sealed class UpdateItemHandler : ICommandHandler<UpdateItem>
{
    private readonly ITimeProvider _timeProvider;
    private readonly IItemsRepository _itemsRepository;

    public UpdateItemHandler(ITimeProvider timeProvider, IItemsRepository itemsRepository)
    {
        _itemsRepository = itemsRepository;
        _timeProvider = timeProvider;
    }

    public async Task HandleAsync(UpdateItem command)
    {
        var item = await _itemsRepository.GetAsync(command.Id)
            ?? throw new ItemNotFoundException(command.Id);

        item.ChangeName(command.Name);
        item.ChangeQuantity(command.Quantity);
        item.ChangeProductId(command.ProductId);
        item.ChangeIsChecked(command.IsChecked);
        item.ChangeModifiedAt(_timeProvider.UtcNow);

        await _itemsRepository.UpdateAsync(item);
    }
}