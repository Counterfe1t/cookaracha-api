using Cookaracha.Application.Abstractions;
using Cookaracha.Core.Abstractions;
using Cookaracha.Core.Entities;
using Cookaracha.Core.Repositories;
using Cookaracha.Core.ValueObjects;

namespace Cookaracha.Application.Commands.Handlers;

public sealed class CreateGroceryListHandler : ICommandHandler<CreateGroceryList>
{
    private readonly ITimeProvider _timeProvider;
    private readonly IGroceryListsRepository _groceryListsRepository;

    public CreateGroceryListHandler(ITimeProvider timeProvider, IGroceryListsRepository groceryListsRepository)
    {
        _timeProvider = timeProvider;
        _groceryListsRepository = groceryListsRepository;
    }

    public async Task HandleAsync(CreateGroceryList command)
    {
        var groceryList = new GroceryList(command.Id, command.Name, new(_timeProvider.UtcNow));
        var items = command.Items.Select(i => new Item(
            Guid.NewGuid(),
            command.Id,
            i.ProductId,
            i.Product?.Name ?? i.Name!,
            i.Quantity,
            new Date(_timeProvider.UtcNow)));

        groceryList.AddItems(items);

        await _groceryListsRepository.AddAsync(groceryList);
    }
}