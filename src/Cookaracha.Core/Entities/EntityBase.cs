using Cookaracha.Core.ValueObjects;

namespace Cookaracha.Core.Entities;

public abstract class EntityBase
{
    public EntityId Id { get; private set; }
    public Date CreatedAt { get; private set; }
    public Date? ModifiedAt { get; protected set; }

    protected EntityBase(EntityId id, Date createdAt)
    {
        Id = id;
        CreatedAt = createdAt;
    }
}