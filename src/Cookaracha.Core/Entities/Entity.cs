using Cookaracha.Core.ValueObjects;

namespace Cookaracha.Core.Entities;

public abstract class Entity
{
    public Date CreatedAt { get; private set; }

    protected Entity(Date createdAt)
    {
        CreatedAt = createdAt;
    }
}