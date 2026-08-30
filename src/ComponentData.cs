namespace Vecs;
public struct ComponentData
{
    public int Id;
    public Array Components;
    public ComponentData(int id, Array array)
    {
        Id = id;
        Components = array;
    }
    public ComponentData(ComponentData old, int count)
    {
        Type type = old.Components.GetType();
        Array array = Array.CreateInstanceFromArrayType(type, count);
        Components = array;
        Id = old.Id;
    }
    // public object? this[int index]
    // {
    //     get => Components.GetValue(index);
    //     set => Components.SetValue(value, index);
    // }
    public T[] GetComponents<T>() => (T[])Components;
    public object? Get(int index) => Components.GetValue(index);
    public void Set<T>(int index, ref T component) => GetComponents<T>()[index] = component;
    public void Set(int index, object? component) => Components.SetValue(component, index);
}