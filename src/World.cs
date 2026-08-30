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
        if (!GetArchetype(currentArchetypeId, out Archetype currentArchetype))
        {
            throw new NotImplementedException();
        }
        if (!GetArchetype(targetArchetypeId, out Archetype targetArchetype))
        {
            targetArchetype = CreateArchetype<T>(currentArchetypeId);
            
        }
        Transfer(entity, component, currentArchetype, targetArchetype);
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
        if (!GetArchetype(currentArchetypeId, out Archetype currentArchetype))
        {
            throw new NotImplementedException();
        }
        ComponentData[] components = currentArchetype.CloneComponents(ArchetypeEntityCount);
        components = [.. components, new (){ Id = Component<T>.Id, Components = new T[ArchetypeEntityCount] }];
        return components;
    }
    // private static Entity CreateEntity(in ArchetypeId archetypeId)
    // {
    //     Entity entity = new (IdGenerator.NextId, archetypeId);
    //     return entity;
    // }
    public bool GetArchetype(in ArchetypeId archetypeId, out Archetype archetype)
    {
        // foreach (Archetype arch in Archetypes)
        // {
        //     if (archetypeId.Id == arch.Id.Id)
        //     {
        //         archetype = arch;
        //         return true;
        //     }
        // }
        for (int i = 0; i < Archetypes.Length; i++)
        {
            if (archetypeId.Id == Archetypes[i].Id.Id)
            {
                archetype = Archetypes[i];
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
        if (!GetArchetype(entity.ArchetypeId, out Archetype archetype))
        {
            throw new NotImplementedException();
        }
        return archetype.Get<T>(entity);
    }
    public void RemoveArchetype(ArchetypeId archetypeId)
    {
        for (int i = 0; i < Archetypes.Length; i++)
        {
            if (archetypeId.Id == Archetypes[i].Id.Id)
            {
                Archetypes.Remove(i);
                break;
            }
        }
    }
    public void SetComponent<T>(in Entity entity, T component)
    {
        if (!GetArchetype(entity.ArchetypeId, out Archetype archetype))
        {
            throw new NotImplementedException();
        }
        archetype.Set(entity, component);
    }
    private void Transfer<T>(Entity entity, T component, Archetype oldArchetype, Archetype newArchetype)
    {
        oldArchetype.Transfer(entity, newArchetype);
        newArchetype.Set(entity, component);
        entity.ArchetypeId = newArchetype.Id;
    }
}