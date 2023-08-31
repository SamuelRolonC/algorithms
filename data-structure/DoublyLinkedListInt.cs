public class DoublyLinkedListInt : IEnumerable
{
    private int Size = 0;
    private Node? Head;
    private Node? Tail;

    public void Clear()
    {
        var traverser = Head;
        while (traverser != null)
        {
            var next = traverser.Next;
            traverser.Previous = null;
            traverser.Next = null;
            traverser.Data = 0;
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

    public void Add(int element)
    {
        AddLast(element);
    }

    public void AddLast(int element)
    {
        if (IsEmpty())
        {
            Head = new Node(element, null, null);
            Tail = Head;
        }
        else
        {
            if (Tail == null) throw new NullNodeLinkedListException("tail");
            Tail.Next = new Node(element, Tail, null);
            Tail = Tail?.Next;
        }
        Size++;
    }

    public void AddFirst(int element)
    {
        if (IsEmpty())
        {
            Head = new Node(element, null, null);
            Tail = Head;
        }
        else
        {
            if (Head == null) throw new NullNodeLinkedListException("head");
            Head.Previous = new Node(element, null, Head);
            Head = Head.Previous;
        }
        Size++;
    }

    public void AddAt(int index, int data)
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
        var newNode = new Node(data, temp, temp?.Next);
        if (temp?.Next == null) throw new NullReferenceException($"Null node was found while adding a element to the list.");
        temp.Next.Previous = newNode;
        temp.Next = newNode;

        Size++;
    }

    public int PeekFirst()
    {
        if (IsEmpty()) throw new EmptyLinkedListException();
        if (Head == null) throw new NullNodeLinkedListException("head");
        return Head.Data;
    }

    public int PeekLast()
    {
        if (IsEmpty()) throw new EmptyLinkedListException();
        if (Tail == null) throw new NullNodeLinkedListException("tail");
        return Tail.Data;
    }

    public int RemoveFirst()
    {
        if (IsEmpty()) throw new EmptyLinkedListException();

        if (Head == null) throw new NullNodeLinkedListException("head");
        var data = Head.Data;
        Head = Head.Next;
        --Size;

        if (IsEmpty())
            Tail = null;
        else
        {
            if (Head == null) throw new NullNodeLinkedListException("head");
            Head.Previous = null;
        }

        return data;
    }

    public int RemoveLast()
    {
        if (IsEmpty()) throw new EmptyLinkedListException();

        if (Tail == null) throw new NullNodeLinkedListException("tail");
        var data = Tail.Data;
        Tail = Tail.Previous;
        --Size;

        if (IsEmpty())
            Head = null;
        else
        {
            if (Tail == null) throw new NullNodeLinkedListException("tail");
            Tail.Next = null;
        }

        return data;
    }

    private int Remove(Node node)
    {
        if (node == null) throw new ArgumentNullException(nameof(node));

        if (node.Previous == null) return RemoveFirst();
        if (node.Next == null) return RemoveLast();

        node.Next.Previous = node.Previous;
        node.Previous.Next = node.Next;

        var data = node.Data;
        node.Previous = null;
        node.Next = null;

        --Size;

        return data;
    }

    public int RemoveAt(int index)
    {
        if (index < 0 || index >= Size)
            throw new ArgumentOutOfRangeException(nameof(index));

        int i;
        Node? traverser;

        if (index < Size / 2)
        {
            if (Head == null) throw new NullNodeLinkedListException("head");
            for (i = 0, traverser = Head; i != index; i++)
            {
                traverser = traverser?.Next;
            }
        }
        else
        {
            if (Tail == null) throw new NullNodeLinkedListException("tail");
            for (i = Size - 1, traverser = Tail; i != index; i--)
            {
                traverser = traverser?.Previous;
            }
        }
        if (traverser == null) throw new NullReferenceException($"Null node was found while removing a element of the list.");
        return Remove(traverser);
    }

    public bool Remove(int value)
    {
        var traverser = Head;

        for (traverser = Head; traverser != null; traverser = traverser.Next)
        {
            if (value == traverser.Data)
            {
                Remove(traverser);
                return true;
            }
        }
        return false;
    }

    public int IndexOf(int value)
    {
        var index = 0;
        var traverser = Head;

        for (; traverser != null; traverser = traverser.Next, index++)
        {
            if (value == traverser.Data)
            {
                return index;
            }
        }
        return -1;
    }

    public bool Contains(int value)
    {
        return IndexOf(value) >= 0;
    }

    public void Reverse()
    {
        ReverseIterative();
    }

    private void ReverseIterative()
    {
        Node? prev = null, current = Head, next = null;
        Tail = Head;
        while (current != null)
        {
            next = current.Next;
            current.Next = prev;
            current.Previous = next;
            prev = current;
            current = next;
        }
        Head = prev;
    }

    public IEnumerator<int> GetEnumerator()
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
        Node? traverser = Head;

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

internal class Node
{
    public int Data;
    public Node? Previous;
    public Node? Next;

    public Node(int data, Node? previous, Node? next)
    {
        Data = data;
        Previous = previous;
        Next = next;
    }

    override public string ToString()
    {
        return Data.ToString();
    }
}

[Serializable]
public class EmptyLinkedListException : Exception
{
    public EmptyLinkedListException() : base("Trying to access an empty list.") { }
}

[Serializable]
public class NullNodeLinkedListException : Exception
{
    public NullNodeLinkedListException(string node) : base($"List's {node} node is null.") { }
}
