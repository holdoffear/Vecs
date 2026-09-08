namespace Vecs;
public struct ArchetypeId : IEquatable<ArchetypeId>
{
    private int Id = 0;
    private ArchetypeId(int id)
    {
        Id = id;
    }
    public ArchetypeId(ComponentId componentId)
    {
        Id = componentId.Id;
    }
    public ArchetypeId(params ComponentId[] componentIds)
    {
        foreach (ComponentId componentId in componentIds)
        {
            Id |= componentId.Id;
        }
    }
    public ArchetypeId(ArchetypeId archetypeId, int bitwiseId)
    {
        Id = archetypeId.Id | bitwiseId;
    }
    public override bool Equals(object? obj) => obj is ArchetypeId archetypeId && Equals(archetypeId);
    public bool Equals(ArchetypeId other) => Id.Equals(other.Id);
    public static bool operator ==(ArchetypeId left, ArchetypeId right) => left.Equals(right);
    public static bool operator !=(ArchetypeId left, ArchetypeId right) => !left.Equals(right);
    public static ArchetypeId operator &(ArchetypeId left, ArchetypeId right) => new(left.Id & right.Id);
    public static ArchetypeId operator |(ArchetypeId left, ComponentId right) => new(left.Id | right.Id);
    public static ArchetypeId operator |(ArchetypeId left, ArchetypeId right) => new(left.Id | right.Id);
    public override int GetHashCode() => Id.GetHashCode();
}