﻿using Cookaracha.Core.Exceptions;
using System.Net;

namespace Cookaracha.Application.Exceptions;

internal sealed class ProductNotFoundException : CustomException
{
    public Guid ProductId { get; }

    public ProductNotFoundException(Guid productId)
        : base($"Product with ID: '{productId}' was not found.")
    {
        StatusCode = (int)HttpStatusCode.NotFound;
        ProductId = productId;
    }
}