namespace Vecs;
public partial class Query
{
    public void Foreach<T1>(Operation<T1> operation)
    {
        Archetype[] archetypes = World.GetArchetypes(GetBits, WithBits, ExcludeBits);
        for (int i = 0; i < archetypes.Length; i++)
        {
            Span<T1> componentsA = archetypes[i].GetComponentsAsSpan<T1>();
            foreach (ref T1 component in componentsA)
            {
                operation(ref component);
            }
        }
    }
    public void Foreach<T1, T2>(Operation<T1, T2> operation)
    {
        Archetype[] archetypes = World.GetArchetypes(GetBits, WithBits, ExcludeBits);
        foreach (Archetype archetype in archetypes)
        {
            Span<T1> componentsA = archetype.GetComponentsAsSpan<T1>();
            Span<T2> componentsB = archetype.GetComponentsAsSpan<T2>();
            for (int i = 0; i < componentsA.Length; i++)
            {
                operation(ref componentsA[i], ref componentsB[i]);
            }
        }
    }
    public void Foreach<T1, T2>(OperationWithEntity<T1, T2> operation)
    {
        Archetype[] archetypes = World.GetArchetypes(GetBits, WithBits, ExcludeBits);
        foreach (Archetype archetype in archetypes)
        {
            Span<Entity> entities = archetype.GetEntitiesAsSpan();
            Span<T1> componentsA = archetype.GetComponentsAsSpan<T1>();
            Span<T2> componentsB = archetype.GetComponentsAsSpan<T2>();
            for (int i = 0; i < componentsA.Length; i++)
            {
                operation(ref entities[i], ref componentsA[i], ref componentsB[i]);
            }
        }
    }
    public void Foreach<T1, T2, T3>(Operation<T1, T2, T3> operation)
    {
        Archetype[] archetypes = World.GetArchetypes(GetBits, WithBits, ExcludeBits);
        foreach (Archetype archetype in archetypes)
        {
            Span<T1> componentsA = archetype.GetComponentsAsSpan<T1>();
            Span<T2> componentsB = archetype.GetComponentsAsSpan<T2>();
            Span<T3> componentsC = archetype.GetComponentsAsSpan<T3>();
            for (int i = 0; i < componentsA.Length; i++)
            {
                operation(ref componentsA[i], ref componentsB[i], ref componentsC[i]);
            }
        }
    }
}