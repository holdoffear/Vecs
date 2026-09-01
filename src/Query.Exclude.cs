namespace Vecs;
public partial class Query
{
    public Query Exclude<T1>()
    {
        ExcludeBits |= Component<T1>.BitwiseId;
        return this;
    }
    public Query Exclude<T1, T2>()
    {
        ExcludeBits |= Component<T1>.BitwiseId|Component<T2>.BitwiseId;
        return this;
    }
    public Query Exclude<T1, T2, T3>()
    {
        ExcludeBits |= Component<T1>.BitwiseId|Component<T2>.BitwiseId|Component<T3>.BitwiseId;
        return this;
    }
}