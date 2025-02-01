using System.Net;

namespace Cookaracha.Core.Exceptions;

internal sealed class InvalidGroceryListNameException : CustomException
{
    public string GroceryListName { get; }

    public InvalidGroceryListNameException(string groceryListName) : base($"Grocery list name: '{groceryListName}' is invalid.")
    {
        StatusCode = (int)HttpStatusCode.BadRequest;
        GroceryListName = groceryListName;
    }
}