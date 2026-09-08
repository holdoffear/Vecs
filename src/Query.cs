namespace Vecs;
public partial class Query
{
    private World World;
    private ArchetypeId WithId;
    private ArchetypeId ExcludeId;
    public Query(World world)
    {
        World = world;
    }
    Archetype[] GetArchetypes(ArchetypeId GetId) => World.GetArchetypes(GetId | WithId, ExcludeId);
    public Query Exclude<T1>()
    {
        ExcludeId |= Component<T1>.GetComponentId();
        return this;
    }
    public Query Exclude<T1, T2>()
    {
        ExcludeId |= new ArchetypeId(Component<T1>.GetComponentId(), Component<T2>.GetComponentId());
        return this;
    }
    public Query With<T1>()
    {
        WithId |= Component<T1>.GetComponentId();
        return this;
    }
    public Query With<T1, T2>()
    {
        WithId |= new ArchetypeId(Component<T1>.GetComponentId(), Component<T2>.GetComponentId());
        return this;
    }
}