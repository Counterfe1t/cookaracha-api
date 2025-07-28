using System.Net;

namespace Cookaracha.Core.Exceptions;

public sealed class ProductNotFoundException : CustomException
{
    public Guid ProductId { get; }

    public ProductNotFoundException(Guid productId)
        : base($"Product with ID: '{productId}' was not found.")
    {
        StatusCode = (int)HttpStatusCode.NotFound;
        ProductId = productId;
    }
}