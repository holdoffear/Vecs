namespace Vecs;
public struct ComponentData
{
    public ComponentId ComponentId;
    public Array Components;
    public ComponentData(ComponentId componentId, Array array)
    {
        ComponentId = componentId;
        Components = array;
    }
    public ComponentData(ComponentData old, int count)
    {
        Type type = old.Components.GetType();
        Components = Array.CreateInstanceFromArrayType(type, count);
        ComponentId = old.ComponentId;
    }
    public T[] GetComponents<T>() => (T[])Components;
    public object? Get(int index) => Components.GetValue(index);
    public void Resize(int size)
    {
        Type type = Components.GetType();
        Array array = Array.CreateInstanceFromArrayType(type, size);
        Array.Copy(Components, array, Math.Min(array.Length, Components.Length));
        Components = array;
    }
    public void Set(int index, object? component) => Components.SetValue(component, index);
    public void SetComponent<T>(int index, in T component)
    {
        T[] components = GetComponents<T>();
        components[index] = component;
    }
}