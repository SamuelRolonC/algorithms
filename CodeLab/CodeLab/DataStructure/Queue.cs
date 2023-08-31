using System.Collections;
using System.Text;

namespace CodeLab.DataStructure
{
    public class Queue<T> : IEnumerable<T> where T : IEquatable<T>
    {
        private LinkedList<T> _list;

        public Queue() { _list = new LinkedList<T>(); }

        public Queue(T firstElement)
        {
            _list = new LinkedList<T>
            {
                firstElement
            };
        }

        public int Size()
        {
            return _list.GetSize();
        }

        public bool IsEmpty()
        {
            return _list.IsEmpty();
        }

        public T Peek()
        {
            if (IsEmpty()) throw new EmptyLinkedListException();
            return _list.PeekFirst();
        }

        public T Poll()
        {
            if (IsEmpty()) throw new EmptyLinkedListException();
            return _list.RemoveFirst();
        }

        public void Offer(T element)
        {
            _list.AddLast(element);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            var result = "[ ";

            foreach (T element in _list)
            {
                result += $"{element}, ";
            }

            if (result.EndsWith(", "))
                result = result.Remove(result.Length - 2, 2);

            result += " ]";
            return result;
        }
    }
}
