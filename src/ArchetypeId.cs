namespace Vecs;
public struct ArchetypeId
{
    public int Id = -1;
    // public Type[] Types;
    public ArchetypeId(int id)
    {
        Id = id;
    }
    public ArchetypeId(ArchetypeId archetypeId, int bitwiseId)
    {
        Id = archetypeId.Id | bitwiseId;
    }
}