using Cookaracha.Core.Exceptions;
using Cookaracha.Core.Sanitization;

namespace Cookaracha.Core.ValueObjects;

public sealed record UserName
{
    public string Value { get; private set; }

    public UserName(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length is > 30 or < 2)
        {
            throw new InvalidUserNameException(value);
        }

        Value = UserNameSanitizer.Sanitize(value);
    }

    public static implicit operator string(UserName name)
        => name.Value;

    public static implicit operator UserName(string value)
        => new(value);

    public static bool operator ==(UserName name, string value)
        => name.Value == value;

    public static bool operator !=(UserName name, string value)
        => name.Value != value;

    public static bool operator ==(string value, UserName name)
        => name.Value == value;

    public static bool operator !=(string value, UserName name)
        => name.Value != value;
}