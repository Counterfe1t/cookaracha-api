using Cookaracha.Application.Abstractions;
using Cookaracha.Core.Exceptions;
using Cookaracha.Core.Repositories;

namespace Cookaracha.Application.Commands.Handlers;

internal sealed class UpdateItemHandler : ICommandHandler<UpdateItem>
{
    private readonly IItemsRepository _itemsRepository;

    public UpdateItemHandler(IItemsRepository itemsRepository)
        => _itemsRepository = itemsRepository;

    public async Task HandleAsync(UpdateItem command)
    {
        var item = await _itemsRepository.GetAsync(command.Id)
            ?? throw new ItemNotFoundException(command.Id);

        item.ChangeName(command.Name);
        item.ChangeQuantity(command.Quantity);
        item.ChangeProductId(command.ProductId);
        item.ChangeIsChecked(command.IsChecked);
        item.Modified();

        await _itemsRepository.UpdateAsync(item);
    }
}