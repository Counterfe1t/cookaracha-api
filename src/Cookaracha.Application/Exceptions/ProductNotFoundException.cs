using Cookaracha.Core.Exceptions;

namespace Cookaracha.Application.Exceptions;

internal sealed class ProductNotFoundException : CustomException
{
    public Guid ProductId { get; }

    public ProductNotFoundException(Guid productId) : base($"Product with ID: '{productId}' was not found.")
    {
        ProductId = productId;
    }
}