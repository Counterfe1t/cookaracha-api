namespace Cookaracha.Core.Exceptions;

internal sealed class InvalidProductNameException : CustomException
{
    public string ProductName { get; }

    public InvalidProductNameException(string productName) : base($"Product name: '{productName}' is invalid.")
    {
        ProductName = productName;
    }
}