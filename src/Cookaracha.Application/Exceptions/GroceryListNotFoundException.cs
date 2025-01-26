using Cookaracha.Core.Exceptions;

namespace Cookaracha.Application.Exceptions;

internal sealed class GroceryListNotFoundException : CustomException
{
    public Guid GroceryListId { get; }

    public GroceryListNotFoundException(Guid groceryListId) : base($"Grocery list with ID: '{groceryListId}' was not found.")
    {
        GroceryListId = groceryListId;
    }
}