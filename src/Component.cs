namespace Vecs;
public static class Component<T>
{
    private static readonly int Id = ComponentIdGenerator.NextId;
    private static readonly int BitwiseId = 1 << Id;
    public static ComponentId GetComponentId() => new(BitwiseId);
}