using CodeLab.DataStructure;

namespace CodeLab.Excercices
{
    public class ExcercicesDoublyLinkedListInt : Excercices, IExcercices
    {
        public void Run()
        {
            Initial(this);

            var linkedList = new DoublyLinkedListInt { 1, 3, 4 };

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
