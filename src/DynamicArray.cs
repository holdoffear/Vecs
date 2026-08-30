using System.Collections;
public struct DynamicArray<T> : IEnumerable<T>
where T : struct
{
    private int NextIndex = 0;
    private T[] Data;
    public int Length
    {
        get => NextIndex;
    }
    public DynamicArray(int count)
    {
        Data = new T[count];
    }
    public ref T this[int index]
    {
        get => ref Data[index];
    }
    public void Add(T element) => Data[NextIndex++] = element;
    public Span<T> AsSpan() => new(Data, 0, Length);
    public IEnumerator<T> GetEnumerator()
    {
        foreach (T element in Data)
        {
            yield return element;
        }
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    public void Remove(int index)
    {
        if (NextIndex > 0)
        {
            Data[index] = Data[--NextIndex];
        }
    }
}