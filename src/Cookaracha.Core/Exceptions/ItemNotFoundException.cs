using System.Net;

namespace Cookaracha.Core.Exceptions;

public sealed class ItemNotFoundException : CustomException
{
    public Guid ItemId { get; }

    public ItemNotFoundException(Guid itemId)
        : base($"Item with ID: '{itemId}' was not found.")
    {
        StatusCode = (int)HttpStatusCode.NotFound;
        ItemId = itemId;
    }
}