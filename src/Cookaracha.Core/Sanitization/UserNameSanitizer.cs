using System.Text.RegularExpressions;

namespace Cookaracha.Core.Sanitization;

public sealed class UserNameSanitizer
{
    public static string Sanitize(string value)
        => Regex.Replace(value.Trim(), @"\s+", " ");
}