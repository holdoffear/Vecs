namespace Vecs;
public struct ArchetypeId
//  : IEqualityOperators<ArchetypeId, Archetype, bool>
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
    // public static bool operator ==(ArchetypeId left, Archetype right) => left.Id == right.ArchetypeId.Id;
    // public static bool operator !=(ArchetypeId left, Archetype right) => left.Id != right.ArchetypeId.Id;
}