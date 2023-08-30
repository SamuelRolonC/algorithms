using CodeLab.DataStructure;

namespace CodeLab.Excercices
{
    public class ExcercicesQueue : Excercices, IExcercices
    {
        public void Run()
        {
            Initialize(this);


            var queue = new DataStructure.Queue<int>();
            
            queue.Offer(1);
            Console.WriteLine($"Added: 1");

            queue.Offer(2);
            Console.WriteLine($"Added: 2");

            queue.Offer(3);
            Console.WriteLine($"Added: 3");

            Console.WriteLine($"{queue}");

            Console.WriteLine($"Dequeue: {queue.Poll()}");

            Console.WriteLine($"Dequeue: {queue.Poll()}");

            Console.WriteLine($"{queue}");
        }
    }
}
