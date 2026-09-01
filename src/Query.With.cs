namespace Vecs;
public partial class Query
{
    public Query With<T1>()
    {
        WithBits |= Component<T1>.BitwiseId;
        return this;
    }
    public Query With<T1, T2>()
    {
        WithBits |= Component<T1>.BitwiseId|Component<T2>.BitwiseId;
        return this;
    }
    public Query With<T1, T2, T3>()
    {
        WithBits |= Component<T1>.BitwiseId|Component<T2>.BitwiseId|Component<T3>.BitwiseId;
        return this;
    }
}