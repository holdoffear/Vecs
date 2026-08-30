namespace Vecs;
public partial class World
{
    public Entity CreateEntity<T1>(T1 componentA)
    {
        ArchetypeId archetypeId = new(Component<T1>.BitwiseId);
        Console.WriteLine(Component<T1>.BitwiseId);
        if (!GetArchetype(archetypeId, out Archetype archetype))
        {
            Console.WriteLine(true);
            ComponentData[] components = [new (Component<T1>.Id, new T1[ArchetypeEntityCount])];
            archetype = CreateArchetype(archetypeId, components);
        }
        Console.WriteLine(archetype.Id.Id);
        Console.WriteLine(archetype.NextIndex);
        Entity entity = archetype.CreateEntity();
        archetype.Set(entity, componentA);
        Console.WriteLine(archetype.NextIndex);
        Console.WriteLine();
        return entity;
    }
    public Entity CreateEntity<T1, T2, T3>(T1 componentA, T2 componentB, T3 componentC)
    {
        ArchetypeId archetypeId = new(Component<T1>.BitwiseId | Component<T2>.BitwiseId | Component<T3>.BitwiseId);
        if (!GetArchetype(archetypeId, out Archetype archetype))
        {
            ComponentData[] components = [new (Component<T1>.Id, new T1[ArchetypeEntityCount]), new (Component<T2>.Id, new T2[ArchetypeEntityCount]), new (Component<T3>.Id, new T3[ArchetypeEntityCount])];
            archetype = CreateArchetype(archetypeId, components);
        }
        Entity entity = archetype.CreateEntity();
        archetype.Set(entity, componentA); archetype.Set(entity, componentB); archetype.Set(entity, componentC);
        return entity;
    }
}