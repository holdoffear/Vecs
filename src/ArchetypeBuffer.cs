namespace Vecs;
public ref struct ArchetypeBuffer
{
    public ref Archetype Buffer;
    public ArchetypeBuffer(ref Archetype archetype)
    {
        Buffer = ref archetype;
    }
}