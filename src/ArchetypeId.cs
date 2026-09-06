namespace Vecs;
public struct ArchetypeId : IEquatable<ArchetypeId>
{
    public int Id = -1;
    public ArchetypeId(int id)
    {
        Id = id;
    }
    public ArchetypeId(ArchetypeId archetypeId, int bitwiseId)
    {
        Id = archetypeId.Id | bitwiseId;
    }
    public override bool Equals(object? obj) => obj is ArchetypeId archetypeId && Equals(archetypeId);
    public bool Equals(ArchetypeId other) => Id.Equals(other.Id);
    public static bool operator ==(ArchetypeId left, ArchetypeId right) => left.Equals(right);
    public static bool operator !=(ArchetypeId left, ArchetypeId right) => !left.Equals(right);
    public override int GetHashCode() => Id.GetHashCode();
}