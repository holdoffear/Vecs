namespace Vecs;
public readonly record struct ComponentId
{
    public readonly int Id;
    public ComponentId(int id)
    {
        Id = id;
    }
    public static ComponentId operator ~(ComponentId right) => new(~right.Id);
    public static ComponentId operator |(ComponentId left, ComponentId right) => new(left.Id | right.Id);
}