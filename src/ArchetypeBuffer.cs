namespace Vecs;
public ref struct ArchetypeBuffer
{
    public ref Archetype Archetype;
    public ArchetypeBuffer(ref Archetype archetype)
    {
        Archetype = ref archetype;
    }
}