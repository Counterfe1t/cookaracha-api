using Cookaracha.Core.ValueObjects;

namespace Cookaracha.Core.Entities;

public sealed class User : EntityBase
{
    public UserName Name { get; private set; }
    public Email Email { get; private set; }
    public Password Password { get; private set; }

    /// <summary>
    /// Empty constructor is required for EF Core property mapping.
    /// </summary>
    User() { }

    public User(
        EntityId id,
        Date createdAt,
        UserName name,
        Email email,
        Password password) : base(id, createdAt)
    {
        Name = name;
        Email = email;
        Password = password;
    }
}