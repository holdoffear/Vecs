namespace Vecs;
public readonly record struct Entity
{
    public readonly EntityId EntityId;
    public readonly ArchetypeId ArchetypeId;
    public readonly int Index = -1;
    internal Entity(EntityId entityId, ArchetypeId archetypeId, int index)
    {
        EntityId = entityId;
        ArchetypeId = archetypeId;
        Index = index;
    }
}