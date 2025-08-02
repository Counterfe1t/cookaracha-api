namespace Cookaracha.Core.ValueObjects;

public sealed record Date
{
    public DateTimeOffset Value { get; }

    public Date(DateTimeOffset value)
    {
        Value = value;
    }

    public static implicit operator DateTimeOffset(Date date)
        => date.Value;

    public static implicit operator Date(DateTimeOffset value)
        => new(value);

    public static bool operator <(Date left, Date right)
        => left.Value < right.Value;

    public static bool operator >(Date left, Date right)
        => left.Value > right.Value;

    public static bool operator <=(Date left, Date right)
        => left.Value <= right.Value;

    public static bool operator >=(Date left, Date right)
        => left.Value >= right.Value;

    public static bool operator ==(DateTimeOffset left, Date right)
        => left == right.Value;
    
    public static bool operator ==(Date left, DateTimeOffset right)
        => left.Value == right;

    public static bool operator !=(DateTimeOffset left, Date right)
        => left != right.Value;
    
    public static bool operator !=(Date left, DateTimeOffset right)
        => left.Value != right;

}