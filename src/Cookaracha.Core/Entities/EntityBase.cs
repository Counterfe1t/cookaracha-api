using Cookaracha.Core.ValueObjects;

namespace Cookaracha.Core.Entities;

public abstract class EntityBase
{
    public EntityId Id { get; private set; }
    public Date CreatedAt { get; private set; }
    public Date? ModifiedAt { get; protected set; }

    /// <summary>
    /// Empty constructor is required for EF Core property mapping.
    /// </summary>
    protected EntityBase() { }

    public EntityBase(EntityId id, Date createdAt)
    {
        Id = id;
        CreatedAt = createdAt;
    }

    public void ChangeModifiedAt(Date modifiedAt)
        => ModifiedAt = modifiedAt;
}