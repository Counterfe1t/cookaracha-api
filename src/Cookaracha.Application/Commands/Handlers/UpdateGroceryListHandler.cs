using Cookaracha.Application.Abstractions;
using Cookaracha.Core.Abstractions;
using Cookaracha.Core.Exceptions;
using Cookaracha.Core.Repositories;

namespace Cookaracha.Application.Commands.Handlers;

public sealed class UpdateGroceryListHandler : ICommandHandler<UpdateGroceryList>
{
    private readonly ITimeProvider _timeProvider;
    private readonly IGroceryListsRepository _groceryListsRepository;

    public UpdateGroceryListHandler(IGroceryListsRepository groceryListsRepository, ITimeProvider timeProvider)
    {
        _groceryListsRepository = groceryListsRepository;
        _timeProvider = timeProvider;
    }

    public async Task HandleAsync(UpdateGroceryList command)
    {
        var groceryList = await _groceryListsRepository.GetAsync(command.Id)
            ?? throw new GroceryListNotFoundException(command.Id);

        groceryList.ChangeGroceryListName(command.Name);
        groceryList.ChangeModifiedAt(_timeProvider.UtcNow);

        await _groceryListsRepository.UpdateAsync(groceryList);
    }
}