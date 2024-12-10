namespace Cookaracha.Core.Exceptions;

internal sealed class InvalidEntityIdException : CustomException
{
    public Guid EntityId { get; }

    public InvalidEntityIdException(Guid entityId) : base($"Entity ID: '{entityId}' is invalid.")
    {
        EntityId = entityId;
    }
}