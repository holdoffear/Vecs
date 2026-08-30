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
    public void AddComponent<T>(Entity entity, T component)
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
        Transfer(entity, component, currentArchetype.Archetype, targetArchetype.Archetype);
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
        ComponentData[] components = currentArchetype.Archetype.CloneComponents(ArchetypeEntityCount);
        components = [.. components, new (){ Id = Component<T>.Id, Components = new T[ArchetypeEntityCount] }];
        return components;
    }
    private bool GetArchetype(in ArchetypeId archetypeId, out ArchetypeBuffer archetypeBuffer)
    {
        for (int i = 0; i < Archetypes.Length; i++)
        {
            if (archetypeId.Id == Archetypes[i].ArchetypeId.Id)
            {
                archetypeBuffer.Archetype = ref Archetypes[i];
                return true;
            }
        }
        archetypeBuffer = default;
        return false;
    }
    public T GetComponent<T>(in Entity entity)
    {
        if (!GetArchetype(entity.ArchetypeId, out ArchetypeBuffer archetypeBuffer))
        {
            throw new NotImplementedException();
        }
        return archetypeBuffer.Archetype.Get<T>(entity);
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
        if (!GetArchetype(entity.ArchetypeId, out ArchetypeBuffer archetypeBuffer))
        {
            throw new NotImplementedException();
        }
        archetypeBuffer.Archetype.Set(entity, component);
    }
    private void Transfer<T>(Entity entity, T component, Archetype oldArchetype, Archetype newArchetype)
    {
        oldArchetype.Transfer(entity, newArchetype);
        newArchetype.Set(entity, component);
        entity.ArchetypeId = newArchetype.ArchetypeId;
    }
}