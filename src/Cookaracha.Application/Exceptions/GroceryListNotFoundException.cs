using Cookaracha.Core.Exceptions;

namespace Cookaracha.Application.Exceptions;

internal sealed class GroceryListNotFoundException : CustomException
{
    public Guid GroceryListId { get; }

    public GroceryListNotFoundException(Guid groceryList) : base($"Product with ID: '{groceryList}' was not found.")
    {
        GroceryListId = groceryList;
    }
}