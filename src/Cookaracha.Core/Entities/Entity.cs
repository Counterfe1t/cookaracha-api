namespace Cookaracha.Core.Entities;

public abstract class Entity
{
    public DateTime CreatedAt { get; private set; }

    protected Entity(DateTime createdAt)
    {
        CreatedAt = createdAt;
    }
}