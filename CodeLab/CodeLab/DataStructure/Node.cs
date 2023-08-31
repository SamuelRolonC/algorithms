namespace CodeLab.DataStructure
{
    public class Node<T>
    {
        public T? Data;
        public Node<T>? Next;

        public Node(T? data, Node<T>? next)
        {
            Data = data;
            Next = next;
        }

        public override string? ToString()
        {
            return Data?.ToString();
        }
    }
}
