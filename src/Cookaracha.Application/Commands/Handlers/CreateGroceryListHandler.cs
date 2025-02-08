using Cookaracha.Application.Abstractions;
using Cookaracha.Core.Abstractions;
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
        => await _groceryListsRepository.AddAsync(new(command.Id, command.Name, new Date(_timeProvider.UtcNow)));
}