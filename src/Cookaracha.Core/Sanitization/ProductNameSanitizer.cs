using System.Text.RegularExpressions;

namespace Cookaracha.Core.Sanitization;

public sealed class ProductNameSanitizer
{
    public static string Sanitize(string value)
        => Regex.Replace(value.ToLower().Trim(), @"\s+", " ");
}