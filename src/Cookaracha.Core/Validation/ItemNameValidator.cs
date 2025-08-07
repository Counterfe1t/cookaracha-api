namespace Cookaracha.Core.Validation;

public sealed class ItemNameValidator
{
    private const int MinLength = 2;
    private const int MaxLength = 50;

    public static bool IsValid(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return false;

        if (value.Length < MinLength || value.Length > MaxLength)
            return false;

        return true;
    }
}