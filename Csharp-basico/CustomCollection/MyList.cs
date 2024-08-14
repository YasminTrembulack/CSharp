using System.Collections;

namespace dotnet_lesson.CustomCollections;

public class ArrayNode<T>
{
    public int Size { get; set; } = 32;
    public int Count { get; set; } = 0;
    public T[] Values { get; set; } = new T[32];
    public ArrayNode<T> Previous {get; set; } = null;
    public ArrayNode<T> Next { get; set; } = null;

    public T this[int index]
    {
        get => Values[index];
        set => Values[index] = value;
    }

    public ArrayNode<T> Add(T value)
    {
        if (Count < Size)
        {
            Values[Count] = value;
            Count++;

            return null;
        }

        if (Next is null)
        {
            var neighbour = new ArrayNode<T>();
            neighbour.Add(value);

            Next = neighbour;

            return neighbour;
        }

        return Next.Add(value);
    }

    public T GetAtIndex(int index)
    {
        if (Values[index] is null)
            throw new NullReferenceException();

        return Values[index];
    }

    public bool Remove(T value)
    {
        for (int i = 0; i < Count; i++)
        {
            if (Values[i].Equals(value))
            {
                PerformSandfall(i);
                return true;
            }
        }

        return Next?.Remove(value) ?? false;
    }

    private void PerformSandfall(int index)
    {
        for (int i = index; i < Count - 1; i++) {
            Values[i] = Values[i+1];
        }

        if (Next is not null)
        {
            Values[Count-1] = Next.GetAtIndex(0);
            Next.PerformSandfall(0);
        } else {
            Values[Count-1] = default;
        }
    }
}

public class MyList<T> : ICollection<T>
{
    public ArrayNode<T> First { get; set; }
    public ArrayNode<T> Last { get; set; }
    public int Count { get; set; }
    public bool IsReadOnly => false;

    public MyList()
    {
        First = new();
        Last = First;
        Count = 0;
    }

    private (ArrayNode<T> node, int index) MapIndexToNode(int index)
    {
        if (index < 0 || index > Count)
            throw new IndexOutOfRangeException();
            
        var currentNode = First;
        int nodesNum = index / 32;

        for (int i = 0; i < nodesNum; i++)
        {
            if (currentNode.Next is not null)
                currentNode = currentNode.Next;
            else
                throw new NullReferenceException();
        }
        
        return (currentNode, index % 32);
    }

    public T this[int index] {
        get
        {
            (ArrayNode<T>, int) reference = MapIndexToNode(index);
            return reference.Item1[reference.Item2];
        }
        set
        {
            (ArrayNode<T>, int) reference = MapIndexToNode(index);
            reference.Item1[reference.Item2] = value;
        }
    }

    public void Add(T item)
    {
        var reference = First.Add(item);
        Count++;

        if (reference is not null)
        {
            Last = reference;
        }
    }

    public void Clear()
    {
        First = new();
        Last = First;
        Count = 0;
    }

    public bool Contains(T item)
    {
        var currentNode = First;

        while (currentNode is not null)
        {
            for (int i = 0; i < 32; i++)
            {
                if (i >= currentNode.Count)
                    break;
                
                T value = currentNode.GetAtIndex(i);
            
                if (value.Equals(item))
                    return true;
            }

            currentNode = currentNode.Next;
        }

        return false;
    }

    public bool Remove(T item)
    {
        return First.Remove(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        var enumerator = GetEnumerator();
        var arrayCount = array.Length;

        var count = 0;
        while (enumerator.MoveNext() && count < arrayCount)
        {
            array[arrayIndex + count] = enumerator.Current;
            count++;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new MyListEnumerator<T>(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}