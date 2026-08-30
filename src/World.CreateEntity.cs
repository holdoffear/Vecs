namespace Vecs;
public partial class World
{
    public Entity CreateEntity<T1>(T1 componentA)
    {
        ArchetypeId archetypeId = new(Component<T1>.BitwiseId);
        if (!GetArchetype(archetypeId, out ArchetypeBuffer archetype))
        {
            ComponentData[] components = [new (Component<T1>.Id, new T1[ArchetypeEntityCount])];
            archetype = new(ref CreateArchetype(archetypeId, components));
        }
        Entity entity = archetype.Buffer.CreateEntity();
        archetype.Buffer.Set(entity, componentA);
        return entity;
    }
    public Entity CreateEntity<T1, T2, T3>(T1 componentA, T2 componentB, T3 componentC)
    {
        ArchetypeId archetypeId = new(Component<T1>.BitwiseId | Component<T2>.BitwiseId | Component<T3>.BitwiseId);
        if (!GetArchetype(archetypeId, out ArchetypeBuffer archetype))
        {
            ComponentData[] components = [new (Component<T1>.Id, new T1[ArchetypeEntityCount]), new (Component<T2>.Id, new T2[ArchetypeEntityCount]), new (Component<T3>.Id, new T3[ArchetypeEntityCount])];
            archetype = new(ref CreateArchetype(archetypeId, components));
        }
        Entity entity = archetype.Buffer.CreateEntity();
        archetype.Buffer.Set(entity, componentA); archetype.Buffer.Set(entity, componentB); archetype.Buffer.Set(entity, componentC);
        return entity;
    }
}