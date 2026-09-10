namespace Vecs;
public readonly record struct ArchetypeId
{
    public readonly int Id = 0;
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
    public static ArchetypeId operator &(ArchetypeId left, ArchetypeId right) => new(left.Id & right.Id);
    public static ArchetypeId operator &(ArchetypeId left, ComponentId right) => new(left.Id & right.Id);
    public static ArchetypeId operator |(ArchetypeId left, ComponentId right) => new(left.Id | right.Id);
    public static ArchetypeId operator |(ArchetypeId left, ArchetypeId right) => new(left.Id | right.Id);
}