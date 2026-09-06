namespace Vecs;
public struct EntityId : IEquatable<EntityId>
{
    public int Id;
    public EntityId(int id)
    {
        Id = id;
    }
    public override bool Equals(object? obj) => obj is EntityId entityId && Equals(entityId);
    public bool Equals(EntityId other) => Id.Equals(other.Id);
    public static bool operator ==(EntityId left, EntityId right) => left.Equals(right);
    public static bool operator !=(EntityId left, EntityId right) => !left.Equals(right);
    public override int GetHashCode() => Id.GetHashCode();
}