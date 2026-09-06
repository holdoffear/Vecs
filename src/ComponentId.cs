namespace Vecs;
public struct ComponentId : IEquatable<ComponentId>
{
    public int Id;
    public ComponentId(int id)
    {
        Id = id;
    }
    public override bool Equals(object? obj) => obj is ComponentId componentId && Equals(componentId);
    public bool Equals(ComponentId other) => Id.Equals(other.Id);
    public static bool operator ==(ComponentId left, ComponentId right) => left.Equals(right);
    public static bool operator !=(ComponentId left, ComponentId right) => !left.Equals(right);
    public override int GetHashCode() => Id.GetHashCode();
}