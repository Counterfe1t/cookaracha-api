using Cookaracha.Core.Exceptions;

namespace Cookaracha.Core.ValueObjects;

public sealed record Password
{
    public string Value { get; private set; }

    public Password(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length is > 200 or < 6)
        {
            throw new InvalidPasswordException();
        }

        Value = value;
    }

    public static implicit operator string(Password password)
        => password.Value;

    public static implicit operator Password(string value)
        => new(value);

    public static bool operator ==(Password password, string value)
        => password.Value == value;

    public static bool operator !=(Password password, string value)
        => password.Value != value;

    public static bool operator ==(string value, Password password)
        => password.Value == value;

    public static bool operator !=(string value, Password password)
        => password.Value != value;
}