namespace Vecs;
public partial class Query
{
    public delegate void Operation<T1>(ref T1 componentA);
	public delegate void Operation<T1, T2>(ref T1 componentA, ref T2 componentB);
	public delegate void Operation<T1, T2, T3>(ref T1 componentA, ref T2 componentB, ref T3 componentC);
	public delegate void Operation<T1, T2, T3, T4>(ref T1 componentA, ref T2 componentB, ref T3 componentC, ref T4 componentD);
	public delegate void Operation<T1, T2, T3, T4, T5>(ref T1 componentA, ref T2 componentB, ref T3 componentC, ref T4 componentD, ref T5 componentE);
	public delegate void Operation<T1, T2, T3, T4, T5, T6>(ref T1 componentA, ref T2 componentB, ref T3 componentC, ref T4 componentD, ref T5 componentE, ref T6 componentF);
	public delegate void Operation<T1, T2, T3, T4, T5, T6, T7>(ref T1 componentA, ref T2 componentB, ref T3 componentC, ref T4 componentD, ref T5 componentE, ref T6 componentF, ref T7 componentG);
	public delegate void Operation<T1, T2, T3, T4, T5, T6, T7, T8>(ref T1 componentA, ref T2 componentB, ref T3 componentC, ref T4 componentD, ref T5 componentE, ref T6 componentF, ref T7 componentG, ref T8 componentH);
    public delegate void OperationWithEntity<T1>(in Entity entity, ref T1 componentA);
	public delegate void OperationWithEntity<T1, T2>(in Entity entity, ref T1 componentA, ref T2 componentB);
	public delegate void OperationWithEntity<T1, T2, T3>(in Entity entity, ref T1 componentA, ref T2 componentB, ref T3 componentC);
	public delegate void OperationWithEntity<T1, T2, T3, T4>(in Entity entity, ref T1 componentA, ref T2 componentB, ref T3 componentC, ref T4 componentD);
	public delegate void OperationWithEntity<T1, T2, T3, T4, T5>(in Entity entity, ref T1 componentA, ref T2 componentB, ref T3 componentC, ref T4 componentD, ref T5 componentE);
	public delegate void OperationWithEntity<T1, T2, T3, T4, T5, T6>(in Entity entity, ref T1 componentA, ref T2 componentB, ref T3 componentC, ref T4 componentD, ref T5 componentE, ref T6 componentF);
	public delegate void OperationWithEntity<T1, T2, T3, T4, T5, T6, T7>(in Entity entity, ref T1 componentA, ref T2 componentB, ref T3 componentC, ref T4 componentD, ref T5 componentE, ref T6 componentF, ref T7 componentG);
	public delegate void OperationWithEntity<T1, T2, T3, T4, T5, T6, T7, T8>(in Entity entity, ref T1 componentA, ref T2 componentB, ref T3 componentC, ref T4 componentD, ref T5 componentE, ref T6 componentF, ref T7 componentG, ref T8 componentH);
    public delegate void OperationWithOnlyEntity<T1>(in Entity entity);
	public delegate void OperationWithOnlyEntity<T1, T2>(in Entity entity);
	public delegate void OperationWithOnlyEntity<T1, T2, T3>(in Entity entity);
	public delegate void OperationWithOnlyEntity<T1, T2, T3, T4>(in Entity entity);
	public delegate void OperationWithOnlyEntity<T1, T2, T3, T4, T5>(in Entity entity);
	public delegate void OperationWithOnlyEntity<T1, T2, T3, T4, T5, T6>(in Entity entity);
	public delegate void OperationWithOnlyEntity<T1, T2, T3, T4, T5, T6, T7>(in Entity entity);
	public delegate void OperationWithOnlyEntity<T1, T2, T3, T4, T5, T6, T7, T8>(in Entity entity);
}