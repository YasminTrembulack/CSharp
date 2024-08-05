using System.Collections;

namespace dotnet_lesson.CustomCollections;

public class MyListEnumerator<T> : IEnumerator<T>
{
    private MyList<T> _list;
    private int _listIndex;
    private ArrayNode<T> _currentNode;
    public T Current { get; set; }
    object IEnumerator.Current => Current;

    public MyListEnumerator(MyList<T> list)
    {
        _list = list;
        Reset();
    }

    public bool MoveNext()
    {
        if (_listIndex < 31) {
            _listIndex++;
            Current = _currentNode.GetAtIndex(_listIndex);

            return true;
        }

        if (_currentNode.Next is not null) {
            _currentNode = _currentNode.Next;
            _listIndex = 0;
            Current = _currentNode.GetAtIndex(_listIndex);

            return true;
        }

        return false;
    }

    public void Dispose() { }

    public void Reset()
    {
        _currentNode = _list.First;
        _listIndex = -1;
        Current = _list.First.GetAtIndex(0);
    }
}