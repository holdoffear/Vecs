namespace Vecs;
public static class Component<T>
{
    public static readonly int Id = IdGenerator.NextId;
    public static readonly int BitwiseId = 1 << Id;
    public static readonly Type ComponentType = typeof(T);
}