namespace Vecs;
public partial class World
{
    private int ArchetypeEntityCount;
    private DynamicArray<Archetype> Archetypes;
    public World(int entityCount)
    {
        ArchetypeEntityCount = entityCount;
        Archetypes = new(5);
    }
    public void Add<T>(Entity entity, T component)
    {
        ArchetypeId currentArchetypeId = entity.ArchetypeId;
        ArchetypeId targetArchetypeId = new (currentArchetypeId, Component<T>.BitwiseId);
        if (!GetArchetype(currentArchetypeId, out ArchetypeBuffer currentArchetype))
        {
            throw new NotImplementedException();
        }
        if (!GetArchetype(targetArchetypeId, out ArchetypeBuffer targetArchetype))
        {
            targetArchetype = new(ref CreateArchetype<T>(currentArchetypeId));
            
        }
        Transfer(entity, component, currentArchetype.Buffer, targetArchetype.Buffer);
    }
    private ref Archetype CreateArchetype<T>(in ArchetypeId currentArchetypeId)
    {
        ArchetypeId targetArchetypeId = new (currentArchetypeId, Component<T>.BitwiseId);
        return ref CreateArchetype(targetArchetypeId, CreateComponents<T>(currentArchetypeId));
    }
    private ref Archetype CreateArchetype(ArchetypeId archetypeId, ComponentData[] components)
    {
        Archetypes.Add(new Archetype(archetypeId, ArchetypeEntityCount, components));
        return ref Archetypes[^1];
    }
    private ComponentData[] CreateComponents<T>(ArchetypeId currentArchetypeId)
    {
        if (!GetArchetype(currentArchetypeId, out ArchetypeBuffer currentArchetype))
        {
            throw new NotImplementedException();
        }
        ComponentData[] components = currentArchetype.Buffer.CloneComponents(ArchetypeEntityCount);
        components = [.. components, new (){ Id = Component<T>.Id, Components = new T[ArchetypeEntityCount] }];
        return components;
    }
    // private static Entity CreateEntity(in ArchetypeId archetypeId)
    // {
    //     Entity entity = new (IdGenerator.NextId, archetypeId);
    //     return entity;
    // }
    private bool GetArchetype(in ArchetypeId archetypeId, out ArchetypeBuffer archetype)
    {
        for (int i = 0; i < Archetypes.Length; i++)
        {
            if (archetypeId.Id == Archetypes[i].ArchetypeId.Id)
            {
                archetype.Buffer = ref Archetypes[i];
                return true;
            }
        }
        archetype = default;
        return false;
    }
    // public Archetype[] GetArchetypes(params int[] componentIds)
    // {
    //     List<Archetype> archetypes = [];
    //     foreach (Archetype archetype in Archetypes)
    //     {
    //         foreach (int id in componentIds)
    //         {
    //             if (!((archetype.Id.Id & id) == 0))
    //             {
    //                 archetypes.Add(archetype);
    //             }
    //         }
    //     }
    //     return [.. archetypes];
    // }
    public T GetComponent<T>(in Entity entity)
    {
        if (!GetArchetype(entity.ArchetypeId, out ArchetypeBuffer archetype))
        {
            throw new NotImplementedException();
        }
        return archetype.Buffer.Get<T>(entity);
    }
    private void RemoveArchetype(ArchetypeId archetypeId)
    {
        for (int i = 0; i < Archetypes.Length; i++)
        {
            if (archetypeId.Id == Archetypes[i].ArchetypeId.Id)
            {
                Archetypes.Remove(i);
                break;
            }
        }
    }
    public void RemoveComponent<T>(Entity entity)
    {
        throw new NotImplementedException();
    }
    public void RemoveEntity(Entity entity)
    {
        throw new NotImplementedException();
    }
    public void SetComponent<T>(in Entity entity, T component)
    {
        if (!GetArchetype(entity.ArchetypeId, out ArchetypeBuffer archetype))
        {
            throw new NotImplementedException();
        }
        archetype.Buffer.Set(entity, component);
    }
    private void Transfer<T>(Entity entity, T component, Archetype oldArchetype, Archetype newArchetype)
    {
        oldArchetype.Transfer(entity, newArchetype);
        newArchetype.Set(entity, component);
        entity.ArchetypeId = newArchetype.ArchetypeId;
    }
}