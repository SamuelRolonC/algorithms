using CodeLab.DataStructure;

namespace CodeLab.Excercices
{
    public class ExcercicesLinkedList : Excercices, IExcercices
    {
        public void Run()
        {
            Initialize(this);

            var linkedList = new DataStructure.LinkedList<char> {  };

            Console.WriteLine($"{linkedList}");
            Console.WriteLine($"Head: {linkedList.PeekFirst()} - Tail: {linkedList.PeekLast()}");

            Console.WriteLine("");
            Console.WriteLine("Reverting list...");
            Console.WriteLine("");

            linkedList.Reverse();

            Console.WriteLine($"{linkedList}");
            Console.WriteLine($"Head: {linkedList.PeekFirst()} - Tail: {linkedList.PeekLast()}");
        }
    }
}
