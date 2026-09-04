using System.Collections;

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
        Components = Array.CreateInstanceFromArrayType(type, count);
        Id = old.Id;
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
}