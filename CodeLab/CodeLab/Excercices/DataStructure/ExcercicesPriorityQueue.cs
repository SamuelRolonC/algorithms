using CodeLab.DataStructure;

namespace CodeLab.Excercices
{
    public class ExcercicesPriorityQueue : Excercices, IExcercices
    {
        public void Run()
        {
            Initialize(this);

            Adding();

            var priorityQueue = new BinaryHeap<int>(new List<int>() { 6, 5, 12, 8, 7, 14, 19, 13, 12, 11 });

            Console.WriteLine($"{priorityQueue}");
            Console.WriteLine("");

            Console.WriteLine($"Adding element 1...");
            priorityQueue.Add(1);
            Console.WriteLine($"Result: {priorityQueue}");
            Console.WriteLine("");

            Console.WriteLine($"Removing element 19...");
            priorityQueue.Remove(19);
            Console.WriteLine($"Result: {priorityQueue}");
            Console.WriteLine("");

            Console.WriteLine($"Clearing queue...");
            priorityQueue.Clear();
            Console.WriteLine($"Result: {priorityQueue}");
            Console.WriteLine("");
        }

        public void Adding()
        {
            var priorityQueue = new BinaryHeap<int>(new List<int>() { 6, 5, 12, 8, 7, 14, 19, 13, 12, 11 });

            Console.WriteLine($"{priorityQueue}");
            Console.WriteLine("");

            Console.WriteLine($"Adding element 1...");
            priorityQueue.Add(1);
            Console.WriteLine($"Result: {priorityQueue}");
            Console.WriteLine("");

            Console.WriteLine($"Adding element 13...");
            priorityQueue.Add(13);
            Console.WriteLine($"Result: {priorityQueue}");
            Console.WriteLine("");

            Console.WriteLine($"Adding element 4...");
            priorityQueue.Add(4);
            Console.WriteLine($"Result: {priorityQueue}");
            Console.WriteLine("");

            Console.WriteLine($"Adding element 0...");
            priorityQueue.Add(0);
            Console.WriteLine($"Result: {priorityQueue}");
            Console.WriteLine("");

            Console.WriteLine($"Adding element 10...");
            priorityQueue.Add(10);
            Console.WriteLine($"Result: {priorityQueue}");
            Console.WriteLine("");
        }
    }
}
