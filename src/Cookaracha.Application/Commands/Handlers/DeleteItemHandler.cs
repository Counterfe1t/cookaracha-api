using Cookaracha.Application.Abstractions;
using Cookaracha.Core.Exceptions;
using Cookaracha.Core.Repositories;

namespace Cookaracha.Application.Commands.Handlers;

internal sealed class DeleteItemHandler : ICommandHandler<DeleteItem>
{
    private readonly IItemsRepository _itemsRepository;

    public DeleteItemHandler(IItemsRepository itemsRepository)
        => _itemsRepository = itemsRepository;

    public async Task HandleAsync(DeleteItem command)
    {
        var item = await _itemsRepository.GetAsync(command.Id)
            ?? throw new ItemNotFoundException(command.Id);

        await _itemsRepository.DeleteAsync(item);
    }
}