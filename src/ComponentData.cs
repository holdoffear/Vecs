namespace Vecs;
public struct ComponentData
{
    public ComponentId ComponentId;
    public Array Components;
    public delegate Array CreateArray(int count);
    public delegate Array ResizeArray(Array array, int size);
    public delegate void TransferComponent(Array source, int sourceIndex, Array target, int targetIndex);
    public CreateArray CreateArrayOperation;
    public ResizeArray ResizeArrayOperation;
    public TransferComponent TransferComponentOperation;
    public ComponentData(ComponentId componentId, Array array, CreateArray createArray, ResizeArray resizeArray, TransferComponent transferArray)
    {
        ComponentId = componentId;
        Components = array;
        CreateArrayOperation = createArray;
        ResizeArrayOperation = resizeArray;
        TransferComponentOperation = transferArray;
    }
    public ComponentData(ComponentData old, int newSize) : this(old.ComponentId, old.CreateArrayOperation(newSize), old.CreateArrayOperation, old.ResizeArrayOperation, old.TransferComponentOperation){}
    public T[] GetComponents<T>() => (T[])Components;
    public void Resize(int size) => Components = ResizeArrayOperation(Components, size);
    public void SetComponent<T>(int index, in T component)
    {
        T[] components = GetComponents<T>();
        components[index] = component;
    }
    public void Transfer(in ComponentData old, int sourceIndex, int targetIndex) => TransferComponentOperation(old.Components, sourceIndex, Components, targetIndex);
}