namespace Vecs;
public struct Archetype
{
    public readonly ArchetypeId ArchetypeId = new(-1);
    public Entity[] Entities = [];
    public ComponentData[] Components = [];
    public int NextIndex = 0;
    public Archetype(ArchetypeId archetypeId, int count, ComponentData[] components)
    {
        ArchetypeId = archetypeId;
        Entities = new Entity[count];
        Components = components;
    }
    // public void Add(in Entity entity)
    // {
    //     Entities[NextIndex] = entity;
    //     Entities[NextIndex].Index = NextIndex++;
    // }
    public ComponentData[] CloneComponents(int count)
    {
        ComponentData[] newComponents = new ComponentData[Components.Length];
        for (int i = 0; i < newComponents.Length; i++)
        {
            newComponents[i] = new(Components[i], count);
        }
        return newComponents;
    }
    public ref Entity CreateEntity()
    {
        Entities[NextIndex] = new(IdGenerator.NextId, ArchetypeId, NextIndex);
        return ref Entities[NextIndex++];
    }
    public ref T Get<T>(Entity entity) => ref GetComponents<T>()[entity.Index];
    public T[] GetComponents<T>()
    {
        if (!GetComponents(Component<T>.Id, out ComponentData componentData))
        {
            throw new NotImplementedException();
        }
        return componentData.GetComponents<T>();
    }
    private bool GetComponents(int id, out ComponentData componentData)
    {
        foreach (ComponentData component in Components)
        {
            if (id == component.Id)
            {
                componentData = component;
                return true;
            }
        }
        componentData = default;
        return false;
    }
    public Span<T> GetComponentsAsSpan<T>() => new(GetComponents<T>(), 0, NextIndex);
    public void Remove(Entity entity)
    {
        RemoveAt(entity.Index);
        NextIndex--;
    }
    private void RemoveAt(int index)
    {
        int lastIndex = NextIndex-1;
        foreach (ComponentData componentData in Components)
        {
            Array.Copy(componentData.Components, lastIndex, componentData.Components, index, 1);
        }
    }
    public void Set<T>(int index, in T component)
    {
        T[] components = GetComponents<T>();
        components[index] = component;
    }
    public void Set<T>(in Entity entity, in T component)
    {
        T[] components = GetComponents<T>();
        components[entity.Index] = component;
    }
    public void Transfer(in Entity entity, in Archetype otherArchetype)
    {
        Entity otherEntity = otherArchetype.CreateEntity();
        int otherIndex = entity.Index;
        int currentIndex = entity.Index;
        foreach (ComponentData component in Components)
        {
            if (otherArchetype.GetComponents(component.Id, out ComponentData otherComponent))
            {
                otherComponent.Set(otherIndex, component.Get(currentIndex));
                // otherComponent[otherIndex] = Components[currentIndex];
            }
        }
        Remove(entity);
    }
}
