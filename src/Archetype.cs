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
    public ref Entity AddEntity(ref Entity entity)
    {
        entity.ArchetypeId = ArchetypeId;
        entity.Index = NextIndex;
        Entities[NextIndex++] = entity;
        return ref entity;
    }
    public ComponentData[] CloneComponents(int count)
    {
        ComponentData[] newComponents = new ComponentData[Components.Length];
        for (int i = 0; i < newComponents.Length; i++)
        {
            newComponents[i] = new(Components[i], count);
        }
        return newComponents;
    }
    public bool Contains(in Entity entity)
    {
        int index = entity.Index;
        if (index < NextIndex)
        {
            return Entities[index].Id == entity.Id;
        }
        return false;
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
    public void Remove(in Entity entity) => RemoveAt(entity.Index);
    private void RemoveAt(int index)
    {
        int lastIndex = NextIndex == 0 ? 0 : NextIndex-1;
        foreach (ComponentData componentData in Components)
        {
            Array.Copy(componentData.Components, lastIndex, componentData.Components, index, 1);
        }
        Entities[index] = Entities[lastIndex];
        NextIndex--;
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
    public void Transfer(ref Entity entity, in Archetype otherArchetype)
    {
        int currentIndex = entity.Index;
        otherArchetype.AddEntity(ref entity);
        int otherIndex = entity.Index;
        foreach (ComponentData component in Components)
        {
            if (otherArchetype.GetComponents(component.Id, out ComponentData otherComponent))
            {
                otherComponent.Set(otherIndex, component.Get(currentIndex));
            }
        }
        RemoveAt(currentIndex);
    }
}
