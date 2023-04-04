public class Stack<T> where T : IEquatable<T>
{
    private LinkedList<T> List { get; set; }

    public Stack() { List = new LinkedList<T>(); }

    public Stack(T firstElement) 
    {
        List = new LinkedList<T>();
        Push(firstElement);
    }

    public int Size()
    {
        return List.GetSize();
    }

    public bool IsEmpty()
    {
        return Size() == 0;
    }

    public void Push(T element)
    {
        List.AddLast(element);
    }

    public void Pop()
    {
        List.RemoveLast();
    }

    public T Peek()
    {
        return List.PeekLast();
    }
}