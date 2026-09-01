namespace Vecs;
public partial class Query
{
    public Query Get<T1>()
    {
        GetBits |= Component<T1>.BitwiseId;
        return this;
    }
    public Query Get<T1, T2>()
    {
        GetBits |= Component<T1>.BitwiseId|Component<T2>.BitwiseId;
        return this;
    }
    public Query Get<T1, T2, T3>()
    {
        GetBits |= Component<T1>.BitwiseId|Component<T2>.BitwiseId|Component<T3>.BitwiseId;
        return this;
    }
}