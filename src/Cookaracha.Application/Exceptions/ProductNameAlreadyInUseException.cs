using Cookaracha.Core.Exceptions;
using System.Net;

namespace Cookaracha.Application.Exceptions;

internal sealed class ProductNameAlreadyInUseException : CustomException
{
    public string ProductName { get; }

    public ProductNameAlreadyInUseException(string productName)
        : base($"Product name: '{productName}' is already in use.")
    {
        StatusCode = (int)HttpStatusCode.BadRequest;
        ProductName = productName;
    }
}