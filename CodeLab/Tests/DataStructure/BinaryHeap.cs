using CodeLab.DataStructure;

namespace Tests.DataStructure
{
    public class BinaryHeap
    {
        [Fact]
        /// <summary>
        /// Test the constructor with parameter List of the BinaryHeap class using a variable intead of literals for the argument of the constructor.
        /// </summary>
        public void ConstructorByList()
        {
            var list = new List<int>() { 6, 5, 12, 8, 7, 14, 19, 13, 12, 11 };
            var priorityQueue = new BinaryHeap<int>(list);
            Assert.Equal(list.Count, priorityQueue.Size());
        }

        [Fact]
        public void Size()
        {
            var priorityQueue = new BinaryHeap<int>();
            Assert.Equal(0, priorityQueue.Size());
        }

        [Fact]
        public void Add()
        {
            var priorityQueue = new BinaryHeap<int>();
            priorityQueue.Add(10);
            Assert.Equal(1, priorityQueue.Size());
        }

        [Fact]
        public void Remove()
        {
            var priorityQueue = new BinaryHeap<int>();
            priorityQueue.Add(10);
            priorityQueue.Remove(10);
            Assert.Equal(0, priorityQueue.Size());
        }

        [Fact]
        public void Clear()
        {
            var priorityQueue = new BinaryHeap<int>();
            priorityQueue.Add(10);
            priorityQueue.Clear();
            Assert.Equal(0, priorityQueue.Size());
        }
    }
}