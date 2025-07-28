using System.Net;

namespace Cookaracha.Core.Exceptions;

internal sealed class InvliadItemNameException : CustomException
{
    public string ItemName { get; }

    public InvliadItemNameException(string itemName)
        : base($"Item name: '{itemName}' is invalid.")
    {
        StatusCode = (int)HttpStatusCode.BadRequest;
        ItemName = itemName;
    }
}