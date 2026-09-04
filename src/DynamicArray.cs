using System.Collections;
public struct DynamicArray<T> : IEnumerable<T>
where T : struct
{
    private int NextIndex = 0;
    private int Size = 0;
    private T[] Data;
    public int Length
    {
        get => NextIndex;
    }
    public DynamicArray(int count)
    {
        Data = new T[count];
        Size = Data.Length;
    }
    public ref T this[int index]
    {
        get => ref Data[index];
    }
    public void Add(T element)
    {
        if (NextIndex < Size)
        {
            Data[NextIndex++] = element;
        }
        else
        {
            Resize();
            Data[NextIndex++] = element;
        }
    }
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
    private void Resize() => Resize(Size*2);
    private void Resize(int newSize)
    {
        Size = newSize;
        Array.Resize(ref Data, Size);
    }
    public void Shrink() => Resize(NextIndex);
}