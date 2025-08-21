using Cookaracha.Core.Exceptions;
using System.Net;

namespace Cookaracha.Application.Exceptions;

internal sealed class EmailAlreadyInUseException : CustomException
{
    public string Email { get; }

    public EmailAlreadyInUseException(string email)
        : base($"Email: '{email}' is already in use.")
    {
        StatusCode = (int)HttpStatusCode.BadRequest;
        Email = email;
    }
}