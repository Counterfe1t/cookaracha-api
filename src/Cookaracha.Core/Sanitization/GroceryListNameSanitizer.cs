using System.Text.RegularExpressions;

namespace Cookaracha.Core.Sanitization;

public sealed class GroceryListNameSanitizer
{
    public static string Sanitize(string value)
        => Regex.Replace(value.Trim(), @"\s+", " ");
}