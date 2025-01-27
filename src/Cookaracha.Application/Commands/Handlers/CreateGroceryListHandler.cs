using Cookaracha.Application.Abstractions;
using Cookaracha.Core.Repositories;

namespace Cookaracha.Application.Commands.Handlers;

public sealed class CreateGroceryListHandler : ICommandHandler<CreateGroceryList>
{
    private readonly IGroceryListsRepository _groceryListsRepository;

    public CreateGroceryListHandler(IGroceryListsRepository groceryListsRepository)
    {
        _groceryListsRepository = groceryListsRepository;
    }

    public async Task HandleAsync(CreateGroceryList command)
        => await _groceryListsRepository.AddAsync(new(command.Id, command.Name));
}