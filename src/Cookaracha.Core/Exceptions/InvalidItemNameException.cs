using System.Net;

namespace Cookaracha.Core.Exceptions;

internal sealed class InvalidItemNameException : CustomException
{
    public string ItemName { get; }

    public InvalidItemNameException(string itemName)
        : base($"Item name: '{itemName}' is invalid.")
    {
        StatusCode = (int)HttpStatusCode.BadRequest;
        ItemName = itemName;
    }
}