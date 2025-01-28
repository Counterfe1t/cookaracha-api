using Cookaracha.Application.Abstractions;
using Cookaracha.Application.Exceptions;
using Cookaracha.Core.Repositories;

namespace Cookaracha.Application.Commands.Handlers;

public sealed class UpdateGroceryListHandler : ICommandHandler<UpdateGroceryList>
{
    private readonly IGroceryListsRepository _groceryListsRepository;

    public UpdateGroceryListHandler(IGroceryListsRepository groceryListsRepository)
    {
        _groceryListsRepository = groceryListsRepository;
    }

    public async Task HandleAsync(UpdateGroceryList command)
    {
        var groceryList = await _groceryListsRepository.GetAsync(command.Id)
            ?? throw new GroceryListNotFoundException(command.Id);

        groceryList.ChangeGroceryListName(command.Name);

        await _groceryListsRepository.UpdateAsync(groceryList);
    }
}