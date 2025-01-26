using Cookaracha.Application.Abstractions;
using Cookaracha.Application.Exceptions;
using Cookaracha.Core.Repositories;

namespace Cookaracha.Application.Commands.Handlers;

public sealed class DeleteGroceryListHandler : ICommandHandler<DeleteGroceryList>
{
    private readonly IGroceryListsRepository _groceryListsRepository;

    public DeleteGroceryListHandler(IGroceryListsRepository groceryListsRepository)
    {
        _groceryListsRepository = groceryListsRepository;
    }

    public async Task HandleAsync(DeleteGroceryList command)
    {
        var groceryList = await _groceryListsRepository.GetAsync(command.Id) ?? throw new GroceryListNotFoundException(command.Id);

        await _groceryListsRepository.DeleteAsync(groceryList);
    }
}