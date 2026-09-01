namespace Vecs;
public struct Entity
{
    public int Id;
    public ArchetypeId ArchetypeId;
    public int Index = -1;
    public Entity(int id, ArchetypeId archetypeId, int index)
    {
        Id = id;
        ArchetypeId = archetypeId;
        Index = index;
    }
}