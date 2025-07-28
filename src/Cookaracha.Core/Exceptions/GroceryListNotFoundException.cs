using System.Net;

namespace Cookaracha.Core.Exceptions;

public sealed class GroceryListNotFoundException : CustomException
{
    public Guid GroceryListId { get; }

    public GroceryListNotFoundException(Guid groceryListId)
        : base($"Grocery list with ID: '{groceryListId}' was not found.")
    {
        StatusCode = (int)HttpStatusCode.NotFound;
        GroceryListId = groceryListId;
    }
}