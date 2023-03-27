using System.Collections;

namespace DynamicArray
{
    public class DoublyLinkedList<T> : IEnumerable<T> where T : class
    {
        private int Size = 0;
        private Node<T>? Head;
        private Node<T>? Tail;

        public void Clear()
        {
            var traverser = Head;
            while(traverser != null)
            {
                var next = traverser.Next;
                traverser.Previous = null;
                traverser.Next = null;
                traverser.Data = null;
                traverser = next;
            }
            Head = null;
            Tail = null;
            traverser = null;
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
                Head = new Node<T>(element, null, null);
                Tail = new Node<T>(element, null, null);
            }
            else
            {
                Tail.Next = new Node<T>(element, Tail, null);
                Tail = Tail.Next;
            }
            Size++;
        }

        public void AddFirst(T element)
        {
            if (IsEmpty())
            {
                Head = new Node<T>(element, null, null);
                Tail = new Node<T>(element, null, null);
            }
            else
            {
                Head.Previous = new Node<T>(element, null, Head);
                Head = Head.Previous;
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
            for(var i = 0; i < index - 1; i++)
            {
                temp = temp?.Next;
            }
            var newNode = new Node<T>(data, temp, temp?.Next);
            temp.Next.Previous = newNode;
            temp.Next = newNode;

            Size++;
        }

        public T PeekLast()
        {
            if (IsEmpty()) throw new Exception("Trying to access an empty list.");
            return Tail?.Data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    internal class Node<T> where T : class
    {
        public T Data;
        public Node<T>? Previous;
        public Node<T>? Next;

        public Node(T data, Node<T>? previous, Node<T>? next)
        {
            Data = data;
            Previous = previous;
            Next = next;
        }

        override public string ToString()
        {
            return Data?.ToString();
        }
    }
}
