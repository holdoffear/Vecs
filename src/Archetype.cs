namespace Vecs;
public struct Archetype : IEquatable<Archetype>
{
    public readonly ArchetypeId ArchetypeId;
    public Entity[] Entities = [];
    public ComponentData[] Components = [];
    public int NextIndex = 0;
    public Archetype(ArchetypeId archetypeId, int count, ComponentData[] components)
    {
        count = count < 1 ? 1 : count;
        ArchetypeId = archetypeId;
        Entities = new Entity[count];
        Components = components;
    }
    public ref Entity AddEntity(ref Entity entity)
    {
        entity = new(entity.Id, ArchetypeId, NextIndex);
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
        if (NextIndex < Entities.Length)
        {
            Entities[NextIndex] = new(IdGenerator.NextId, ArchetypeId, NextIndex);
        }
        else
        {
            Resize();
            Entities[NextIndex] = new(IdGenerator.NextId, ArchetypeId, NextIndex);
        }
        return ref Entities[NextIndex++];
    }
    public override bool Equals(object? obj) => obj is Archetype archetype && Equals(archetype);
    public bool Equals(Archetype other) => ArchetypeId == other.ArchetypeId;
    public ref T Get<T>(Entity entity) => ref GetComponents<T>()[entity.Index];
    public T[] GetComponents<T>()
    {
        ComponentId componentId = Component<T>.GetComponentId();
        if (GetComponents(componentId, out ComponentData componentData))
        {
            return componentData.GetComponents<T>();
        }
        return [];
    }
    private bool GetComponents(ComponentId componentId, out ComponentData componentData)
    {
        foreach (ComponentData component in Components)
        {
            if (componentId == component.ComponentId)
            {
                componentData = component;
                return true;
            }
        }
        componentData = default;
        return false;
    }
    public Span<T> GetComponentsAsSpan<T>() => new(GetComponents<T>(), 0, NextIndex);
    public Span<Entity> GetEntitiesAsSpan() => new(Entities, 0, NextIndex);
    public override int GetHashCode() => ArchetypeId.GetHashCode();
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
    private void Resize() => Resize(Entities.Length*2);
    private void Resize(int newSize)
    {
        Array.Resize(ref Entities, newSize);
        for (int i = 0; i < Components.Length; i++)
        {
            Components[i].Resize(newSize);
        }
    }
    public void Set<T>(in Entity entity, in T component)
    {
        if (GetComponents(Component<T>.GetComponentId(), out ComponentData componentData))
        {
            T[] components = componentData.GetComponents<T>();
            components[entity.Index] = component;
        }
    }
    public void Shrink() => Resize(NextIndex);
    public void Transfer(ref Entity entity, in Archetype otherArchetype)
    {
        int currentIndex = entity.Index;
        otherArchetype.AddEntity(ref entity);
        int otherIndex = entity.Index;
        foreach (ComponentData component in Components)
        {
            if (otherArchetype.GetComponents(component.ComponentId, out ComponentData otherComponent))
            {
                otherComponent.Set(otherIndex, component.Get(currentIndex));
            }
        }
        RemoveAt(currentIndex);
    }
    public static bool operator ==(Archetype left, Archetype right) => left.Equals(right);
    public static bool operator !=(Archetype left, Archetype right) => !left.Equals(right);
}
