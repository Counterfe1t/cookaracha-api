using System.Text.RegularExpressions;

namespace Cookaracha.Core.Sanitization;

public sealed class ProductNameSanitizer
{
    public static string Sanitize(string value)
        => string.IsNullOrWhiteSpace(value)
            ? string.Empty
            : Regex.Replace(value.ToLower().Trim(), @"\s+", " ");
}