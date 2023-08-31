public class LinkedList<T> : IEnumerable<T> where T : IEquatable<T>
{
    private int Size = 0;
    private Node<T?>? Head;
    private Node<T?>? Tail;

    public void Clear()
    {
        var traverser = Head;
        while (traverser != null)
        {
            var next = traverser.Next;
            traverser.Next = null;
            traverser.Data = default(T);
            traverser = next;
        }
        Head = null;
        Tail = null;
        Size = 0;
    }

    public int GetSize()
    {
        return Size;
    }

    public bool IsEmpty()
    {
        return Size == 0;
    }

    public void Add(T element)
    {
        AddLast(element);
    }

    public void AddLast(T element)
    {
        if (IsEmpty())
        {
            Head = new Node<T>(element, null);
            Tail = Head;
        }
        else
        {
            if (Tail == null) throw new NullNodeLinkedListException("tail");
            Tail.Next = new Node<T>(element, null);
            Tail = Tail.Next;
        }
        Size++;
    }

    public void AddFirst(T element)
    {
        if (IsEmpty())
        {
            Head = new Node<T>(element, null);
            Tail = Head;
        }
        else
        {
            var newNode = new Node<T>(element, Head);
            Head = newNode;
        }
        Size++;
    }

    public void AddAt(int index, T data)
    {
        if (index < 0 || index >= Size)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        if (index == 0)
        {
            AddFirst(data);
            return;
        }
        else if (index == Size - 1)
        {
            AddLast(data);
            return;
        }

        var temp = Head;
        for (var i = 0; i < index - 1; i++)
        {
            temp = temp?.Next;
        }
        var newNode = new Node<T>(data, temp?.Next);
        temp.Next = newNode;

        Size++;
    }

    public T PeekFirst()
    {
        if (IsEmpty()) throw new Exception("Trying to access an empty list.");
        return Head.Data;
    }

    public T PeekLast()
    {
        if (IsEmpty()) throw new Exception("Trying to access an empty list.");
        return Tail.Data;
    }

    public T RemoveFirst()
    {
        if (IsEmpty()) throw new EmptyLinkedListException();

        var data = Head.Data;
        Head = Head.Next;
        --Size;

        if (IsEmpty())
            Tail = null;

        return data;
    }

    public T RemoveLast()
    {
        if (IsEmpty()) throw new EmptyLinkedListException();

        var data = Tail.Data;
        if (Size == 1)
            Tail = null;
        else
        {
            var temp = Head;
            for(var i = 0; i < Size - 2; i++)
            {
                temp = temp.Next;
            }
            Tail = temp;
        }
        --Size;

        if (IsEmpty())
            Head = null;
        else
            Tail.Next = null;

        return data;
    }

    private T Remove(Node<T> node)
    {
        if (node == null) throw new ArgumentNullException(nameof(node));

        if (node == Head) return RemoveFirst();
        if (node.Next == null) return RemoveLast();
        
        var temp = Head;
        for (var i = 0; i < Size - 2; i++)
        {
            if (node == temp.Next)
                break;
            temp = temp.Next;
        }
        temp.Next = temp.Next.Next;

        --Size;

        return node.Data;
    }

    public T RemoveAt(int index)
    {
        if (index < 0 || index >= Size)
            throw new ArgumentOutOfRangeException(nameof(index));

        if (index == 0) return Remove(Head);
        if (index == Size - 1) return Remove(Tail);

        int i;
        Node<T> traverser;

        for (i = 0, traverser = Head; i != index; i++)
            traverser = traverser.Next;

        return Remove(traverser);
    }

    public bool Remove(T value)
    {
        for (var traverser = Head; traverser != null; traverser = traverser.Next)
        {
            if (value.Equals(traverser.Data))
            {
                Remove(traverser);
                return true;
            }
        }
        return false;
    }

    public int IndexOf(T value)
    {
        var index = 0;
        var traverser = Head;

        for (; traverser != null; traverser = traverser.Next, index++)
        {
            if (value.Equals(traverser.Data))
            {
                return index;
            }
        }
        return -1;
    }

    public bool Contains(T value)
    {
        return IndexOf(value) >= 0;
    }

    public void Reverse()
    {
        ReverseIterative();
    }

    private void ReverseIterative()
    {
        Node<T> previous = null, current = Head, next = null;
        Tail = Head;
        while (current != null)
        {
            next = current.Next;
            current.Next = previous;
            previous = current;
            current = next;
        }
        Head = current;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var traverser = Head;

        for (; traverser != null; traverser = traverser.Next)
        {
            yield return traverser.Data;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public override string ToString()
    {
        if (Head == null) throw new NullNodeLinkedListException("head");

        StringBuilder sb = new StringBuilder();
        sb.Append("[ ");
        Node<T> traverser = Head;

        while (traverser != null)
        {
            sb.Append(traverser.Data);
            if (traverser.Next != null)
                sb.Append(", ");
            traverser = traverser?.Next;
        }
        sb.Append(" ]");
        return sb.ToString();
    }
}
