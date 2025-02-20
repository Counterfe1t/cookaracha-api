using Cookaracha.Core.ValueObjects;

namespace Cookaracha.Core.Entities;

// TODO: Add entity modification date field
public abstract class Entity
{
    public Date CreatedAt { get; private set; }

    protected Entity(Date createdAt)
    {
        CreatedAt = createdAt;
    }
}