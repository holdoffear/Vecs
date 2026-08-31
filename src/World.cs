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
    public void AddComponent<T>(ref Entity entity, in T component)
    {
        ArchetypeId currentArchetypeId = entity.ArchetypeId;
        ArchetypeId targetArchetypeId = new(currentArchetypeId, Component<T>.BitwiseId);
        if (!GetArchetype(currentArchetypeId, out ArchetypeBuffer currentArchetype))
        {
            throw new NotImplementedException();
        }
        if (!GetArchetype(targetArchetypeId, out ArchetypeBuffer targetArchetype))
        {
            targetArchetype = new(ref CreateArchetype(targetArchetypeId, CreateComponents<T>(currentArchetypeId)));
        }
        Transfer(ref entity, component, currentArchetype.Archetype, targetArchetype.Archetype);
    }
    private ref Archetype CreateArchetype(ArchetypeId archetypeId, ComponentData[] components)
    {
        Archetypes.Add(new Archetype(archetypeId, ArchetypeEntityCount, components));
        return ref Archetypes[^1];
    }
    private ComponentData[] CreateComponents<T>(in ArchetypeId currentArchetypeId)
    {
        if (!GetArchetype(currentArchetypeId, out ArchetypeBuffer currentArchetype))
        {
            throw new NotImplementedException();
        }
        ComponentData[] components = currentArchetype.Archetype.CloneComponents(ArchetypeEntityCount);
        components = [.. components, new (Component<T>.Id, new T[ArchetypeEntityCount])];
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
    public Archetype[] GetArchetypes(int getBits, int withBits, int excludeBits)
    {
        throw new NotImplementedException();
    }
    public T GetComponent<T>(in Entity entity)
    {
        if (!GetArchetype(entity.ArchetypeId, out ArchetypeBuffer archetypeBuffer))
        {
            throw new NotImplementedException();
        }
        return archetypeBuffer.Archetype.Get<T>(entity);
    }
    public bool IsValid(in Entity entity)
    {
        if (!GetArchetype(entity.ArchetypeId, out ArchetypeBuffer archetypeBuffer))
        {
            throw new NotImplementedException();
        }
        return archetypeBuffer.Archetype.Contains(entity);
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
    public void RemoveComponent<T>(ref Entity entity)
    {
        ArchetypeId currentArchetypeId = entity.ArchetypeId;
        ArchetypeId targetArchetypeId = new(currentArchetypeId.Id &~ Component<T>.BitwiseId);
        if (!GetArchetype(currentArchetypeId, out ArchetypeBuffer currentArchetype))
        {
            throw new NotImplementedException();
        }
        if (!GetArchetype(targetArchetypeId, out ArchetypeBuffer targetArchetype))
        {
            targetArchetype = new(ref CreateArchetype(targetArchetypeId, CreateComponents<T>(currentArchetypeId)));
        }
        Transfer(ref entity, currentArchetype.Archetype, targetArchetype.Archetype);
    }
    public void RemoveEntity(in Entity entity)
    {
        if (!GetArchetype(entity.ArchetypeId, out ArchetypeBuffer archetypeBuffer))
        {
            throw new NotImplementedException();
        }
        archetypeBuffer.Archetype.Remove(entity);
    }
    public void SetComponent<T>(in Entity entity, T component)
    {
        if (!GetArchetype(entity.ArchetypeId, out ArchetypeBuffer archetypeBuffer))
        {
            throw new NotImplementedException();
        }
        archetypeBuffer.Archetype.Set(entity, component);
    }
    private void Transfer<T>(ref Entity entity, in T component, in Archetype oldArchetype, in Archetype newArchetype)
    {
        oldArchetype.Transfer(ref entity, newArchetype);
        newArchetype.Set(entity, component);
    }
    private void Transfer(ref Entity entity, in Archetype oldArchetype, in Archetype newArchetype)
    {
        oldArchetype.Transfer(ref entity, newArchetype);
    }
}