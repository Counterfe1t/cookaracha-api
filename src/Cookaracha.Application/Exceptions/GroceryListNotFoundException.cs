using Cookaracha.Core.Exceptions;
using System.Net;

namespace Cookaracha.Application.Exceptions;

internal sealed class GroceryListNotFoundException : CustomException
{
    public Guid GroceryListId { get; }

    public GroceryListNotFoundException(Guid groceryListId)
        : base($"Grocery list with ID: '{groceryListId}' was not found.")
    {
        StatusCode = (int)HttpStatusCode.NotFound;
        GroceryListId = groceryListId;
    }
}