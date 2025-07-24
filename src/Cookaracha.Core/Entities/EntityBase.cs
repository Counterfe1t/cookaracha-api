using Cookaracha.Core.ValueObjects;

namespace Cookaracha.Core.Entities;

public abstract class EntityBase
{
    public Date CreatedAt { get; private set; }
    public Date? ModifiedAt { get; protected set; }

    protected EntityBase(Date createdAt)
    {
        CreatedAt = createdAt;
    }
}