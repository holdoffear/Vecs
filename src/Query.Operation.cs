namespace Vecs;
public partial class Query
{
    public delegate void Operation<T1>(ref T1 componentA);
    public delegate void Operation<T1, T2>(ref T1 componentA, ref T2 componentB);
    public delegate void Operation<T1, T2, T3>(ref T1 componentA, ref T2 componentB, ref T3 componentC);
}