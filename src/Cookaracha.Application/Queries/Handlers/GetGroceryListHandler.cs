using Cookaracha.Application.Abstractions;
using Cookaracha.Application.DTO;
using Cookaracha.Application.Exceptions;
using Cookaracha.Core.Repositories;

namespace Cookaracha.Application.Queries.Handlers;

public sealed class GetGroceryListHandler : IQueryHandler<GetGroceryList, GroceryListDto>
{
    private readonly IGroceryListsRepository _groceryListsRepository;

    public GetGroceryListHandler(IGroceryListsRepository groceryListsRepository)
    {
        _groceryListsRepository = groceryListsRepository;
    }

    public async Task<GroceryListDto> HandleAsync(GetGroceryList command)
    {
        var groceryList = await _groceryListsRepository.GetAsync(command.GroceryListId)
            ?? throw new GroceryListNotFoundException(command.GroceryListId);

        return new()
        {
            Id = groceryList.Id,
            Name = groceryList.Name,
        };
    }
}