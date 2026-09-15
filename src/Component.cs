namespace Vecs;
public static class Component<T>
{
    private static readonly int Id = ComponentIdGenerator.NextId;
    private static readonly int BitwiseId = 1 << Id;
    private static ComponentData.CreateArray CreateArray = static (int count) =>
    {
        return new T[count];
    };
    private static ComponentData.ResizeArray ResizeArray = static (Array array, int newSize) =>
    {
        T[] target = (T[])array;
        Array.Resize(ref target, newSize);
        return target;
    };
    private static ComponentData.TransferComponent Transfer = static (Array sourceArray, int sourceIndex, Array targetArray, int targetIndex) =>
    {
        T[] source = (T[])sourceArray;
        T[] target = (T[])targetArray;
        target[targetIndex] = source[sourceIndex];
    };
    public static ComponentId GetComponentId() => new(BitwiseId);
    public static ComponentData GetComponentData(int count) => new(GetComponentId(), CreateArray(count), CreateArray, ResizeArray, Transfer);
}