namespace Cookaracha.Core.Exceptions;

public abstract class CustomException : Exception
{
    public int StatusCode { get; protected set; }

    protected CustomException(string message) : base(message) { }
}